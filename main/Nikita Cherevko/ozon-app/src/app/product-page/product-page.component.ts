import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { ProductService } from '../services/product.service';
import { Product } from '../interfaces/product';
import { EventBusService } from '../services/event-bus.service';
import { CartProduct } from '../interfaces/cartProduct';
// import { EventBusService } from '../services/event-bus.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css'],
})
export class ProductPageComponent implements OnInit {
  product: Product;
  cartProduct: CartProduct;
  cartProducts: CartProduct[] = [];
  buttonColor: string;
  selectedItem: string;
  backgroundSwitch: boolean = false;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private eventBusService: EventBusService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.productService
        .getProductById(params.id)
        .subscribe((product) => (this.product = product[0]));
      this.getCartProductById(params.id);
    });
    this.getCartProducts();
  }

  getCartProductById(id: string) {
    this.productService.getCartProductById(id).subscribe((response) => {
      // console.log('response', response);
      this.cartProduct = response[0];
    });
  }

  getCartProducts() {
    this.productService
      .getCartProducts()
      .subscribe((cartProducts) => (this.cartProducts = cartProducts));
  }

  addProductToCart() {
    if (this.cartProduct) {
      this.cartProduct.quantity++;
      this.productService
        .putCartProduct(this.cartProduct)
        .subscribe((response) => {
          console.log(response);
        });
    } else if (this.cartProduct == undefined) {
      this.cartProduct = this.product as CartProduct;
      this.cartProduct.quantity = 1;
      this.productService.postCartProduct(this.cartProduct).subscribe();
      this.cartProducts.push(this.cartProduct);
    }
    this.eventBusService.changeData(this.cartProducts);
  }
}
