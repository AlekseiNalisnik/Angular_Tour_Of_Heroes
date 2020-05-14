import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { Product } from '../../interfaces/product';
import { BasketProduct } from '../../interfaces/basketProduct';
@Component({
  selector: 'app-main-product',
  templateUrl: './main-product.component.html',
  styleUrls: ['./main-product.component.css']
})
export class MainProductComponent implements OnInit {
  @Input() isProductInBasket: boolean;
  @Input() basketProduct: BasketProduct;
  @Output() currentProductForOutput: EventEmitter<Product> = new EventEmitter<Product>();

  constructor() { }

  ngOnInit(): void {
  }

  addProductToBasket(basketProduct) {
    this.basketProduct.quantity = 1;
    this.currentProductForOutput.emit(this.basketProduct);
  }
}