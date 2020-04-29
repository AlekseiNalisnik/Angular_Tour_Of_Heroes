import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Product } from './product';
import { PRODUCTS } from './product-mock';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor() { }

  getProducts(): Observable<Product[]> {
    return of(PRODUCTS);
  }
}