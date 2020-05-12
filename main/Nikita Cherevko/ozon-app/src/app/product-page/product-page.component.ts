import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { ProductService } from '../services/product.service';
import { Product } from '../interfaces/product';
import { MaindbService } from '../services/maindb.service';
import { ObservableService } from '../services/observable.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css'],
})
export class ProductPageComponent implements OnInit {
  cartProducts: Product[] = [];
  product: Product;
  buttonColor: string;
  selectedItem: string;
  backgroundSwitch: boolean = false;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private maindb: MaindbService,
    private observableService: ObservableService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      console.log(params);
      this.product = this.maindb.getProductById(+params.id);
    });

    this.cartProducts = this.observableService.lastProducts;
    console.log('products fetched', this.cartProducts);

    for(let cartProduct of this.cartProducts) {
      if(this.product.id == cartProduct.id)
        this.product = cartProduct;
    }
  }

  addProductToCart() {
    if (this.isProductInCart(this.product)) {
      this.cartProducts.push(this.product);
      this.observableService.addToHeader(this.cartProducts);
    }
    this.product.quantity++;

    this.productService
      .putCartProduct(this.product)
      .subscribe((response) => {
        console.log(response);
      });
  }

  // activeNow(item: string) {
  //   this.selectedItem = item;
  // }

  isProductInCart(product: Product): boolean {
    for(let i = 0; i < this.cartProducts.length; i++) {
      if(this.cartProducts[i].id === product.id) {
        return false;
      }
    }
    return true;
  }

}
