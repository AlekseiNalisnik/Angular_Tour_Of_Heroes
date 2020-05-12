import { Component, OnInit } from '@angular/core';

import { Product } from '../interfaces/product';
import { ProductService } from '../services/product.service';
import { BasketLenghtService } from '../services/basket-lenght.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  products: Product[] = [];
  basketProducts: Product[] = this.basketLenghtService.basketProducts;

  constructor(
    private productService: ProductService,
    private basketLenghtService: BasketLenghtService
  ) { }

  ngOnInit(): void {
    this.getAllProducts();
  }

  getAllProducts(): void {
    this.productService.getProducts()
      .subscribe(products => {
        this.products = products;
      });
  }

  addProductToBasket(product) {
    this.productService.postProduct(product)
    .subscribe(() => {
      if(this.isProductInBasket(product) === true) {
        this.basketProducts.push(product);
      };
      this.basketLenghtService.addToInventory(this.basketProducts);
    });
  }

  isProductInBasket(product: Product): boolean {
    for(let i = 0; i < this.basketProducts.length; i++) {
      if(this.basketProducts[i].id === product.id) {
        return false;
      }
    }
    return true;
  }
}
