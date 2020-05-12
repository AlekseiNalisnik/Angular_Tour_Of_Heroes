import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../interfaces/product';

@Injectable({
  providedIn: 'root'
})
export class ObservableService {

  lastProducts: Product[] = [];

  
  private inventorySubject$ = new BehaviorSubject<Product[]>(this.lastProducts);

  constructor() { }

  addToHeader(products: Product[]) {
    this.lastProducts = products;
    this.inventorySubject$.next(products);
    console.log(this.lastProducts);
  }

}
