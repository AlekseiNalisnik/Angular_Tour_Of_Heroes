import { Component, OnInit } from '@angular/core';

import { Product } from '../interfaces/product';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  basketProducts: Product[] = [];

  constructor() { }

  ngOnInit(): void {

  }

  onBasketChange(basketProducts) {
    this.basketProducts = basketProducts;
    console.log('this.basketProducts - ', this.basketProducts);
  }
}
