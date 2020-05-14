import { Component, OnInit } from '@angular/core';

import { Product } from '../interfaces/product';
import { BasketProduct } from '../interfaces/basketProduct';
import { ProductService } from '../services/product.service';
import { EventBusService } from '../services/event-bus.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  products: Product[] = [];
  basketProducts: BasketProduct[] = [];

  constructor(
    private productService: ProductService,
    private eventBusService: EventBusService
  ) { }

  ngOnInit(): void {
    this.getAllProducts();
    this.getAllBasketProducts();
  }

  getAllProducts(): void {
    this.productService.getProducts()
      .subscribe(products => {
        this.products = products;
      });
  }

  getAllBasketProducts(): void {
    this.productService.getBasketProducts()
    .subscribe(basketProducts => {
      this.basketProducts = basketProducts;
    });
  }

  addProductToBasket(product) {
    this.productService.postProduct(product)
      .subscribe((p) => {
        if(p === null) {
          return;
        } else {
          this.basketProducts.push(product);
        }
        this.eventBusService.changeData(this.basketProducts);
      });
  }

  isProductInBasket(product): boolean {
    for(let i = 0; i < this.basketProducts.length; i++) {
      if(this.basketProducts[i].id === product.id) {
        return true;
      }
    }
    return false;
  }
}
