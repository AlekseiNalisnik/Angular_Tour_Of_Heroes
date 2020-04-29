import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import {Product} from './product';
import {Products} from './mock-products';
import {User} from './user';
import {Users} from './mock-users';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor() { }

  getProducts(): Observable<Product[]> {
    return of(Products);
  }


}
