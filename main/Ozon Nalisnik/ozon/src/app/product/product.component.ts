import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { BasketProduct } from '../interfaces/basketProduct';
import { Product } from '../interfaces/product';
import { ProductService } from '../services/product.service';
import { EventBusService } from '../services/event-bus.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  product: Product;
  basketProduct: BasketProduct;
  basketProducts: BasketProduct[] = [];

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private eventBusService: EventBusService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.productService.getProductById(params.id)
        .subscribe(product => {
          this.product = product[0];
          console.log('this.product PRODUCT - ', product);
        })
      this.productService.getBasketProductById(params.id)
        .subscribe(response => {
          this.basketProduct = response[0] || this.product;
          console.log('this.basketProduct PRODUCT - ', this.basketProduct);
        });
    });
    this.productService.getBasketProducts()
      .subscribe(prs => this.basketProducts = prs);
  }

  addProductToBasket() {
    if(this.basketProduct.quantity == 0) {
      this.basketProduct.quantity++;
      this.productService.postProduct(this.basketProduct)
        .subscribe(res => console.log('RRRRRRRКККККККККККККR - ', this.basketProduct))
      this.basketProducts.push(this.basketProduct);
    } else {
      console.log('Я нахожусь в ADD и мой баскет - ', this.basketProduct)
      this.basketProduct.quantity++;
      this.productService.updateBasketProduct(this.basketProduct)
        .subscribe(res => console.log('R - ', res))
    }
    this.eventBusService.changeData(this.basketProducts);
  }
}