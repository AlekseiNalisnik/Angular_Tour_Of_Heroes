import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

import { Product } from '../interfaces/product';

// Сервис-Наблюдатель
@Injectable({
  providedIn: 'root'
})
export class BasketLenghtService {
  basketProducts: Product[] = [];
  private inventorySubject$ = new BehaviorSubject<Product[]>(this.basketProducts);

  constructor() { }

  addToInventory(basketProducts: Product[]) {
    this.inventorySubject$.next(basketProducts);
    this.basketProducts = basketProducts;
    // console.log('basketProducts - ', this.basketProducts);
  }
}
