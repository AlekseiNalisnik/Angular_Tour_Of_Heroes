import { Component, OnInit } from '@angular/core';

import { Product } from '../interfaces/product';
import { ProductService } from '../services/product.service';
import { BasketLenghtService } from '../services/basket-lenght.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  basketProducts: Product[] = [];
  masterSelected: boolean = false;

  constructor(
    private productService: ProductService,
    private basketLenghtService: BasketLenghtService
  ) { }

  ngOnInit(): void {
    this.getAllBasketProducts();
  }

  onBasketChange(basketProducts) {
    this.basketProducts = basketProducts;
  }

  getAllBasketProducts(): void {
    this.productService.getBasketProducts()
      .subscribe(products => {
        this.basketProducts = products;
        this.basketLenghtService.addToInventory(this.basketProducts);
      });
  }

  deleteProductFromBasket(product) {
    const productId = product.id;
    this.productService.deleteBasketProduct(productId)
    .subscribe(() => {
      this.basketProducts = this.basketProducts.filter(
        product => product.id !== productId
      );
      this.basketLenghtService.addToInventory(this.basketProducts);
    });
  }

  deleteCheckedProductsFromBasket() {
    for(let i = 0; i < this.basketProducts.length; i++) {
      if(this.basketProducts[i].isSelected == true) {
        this.deleteProductFromBasket(this.basketProducts[i]);
      }
    }
    this.basketLenghtService.addToInventory(this.basketProducts);
  }

  checkUncheckAll() {
    for(let i = 0; i < this.basketProducts.length; i++) {
      this.basketProducts[i].isSelected = this.masterSelected;
    }
    this.basketLenghtService.addToInventory(this.basketProducts);
  }

  changeMasterSelected(masterSelected) {
    console.log('masterSelected - ', masterSelected);
    this.masterSelected = masterSelected;
  }
}
