import { Component, OnInit } from '@angular/core';
import { Product } from '../interfaces/product';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  products: Product[] = [];

  constructor() {}

  ngOnInit(): void {}

  onBasketChange(products) {
    this.products = products;
    console.log('this.products - ', this.products);
  }

}
