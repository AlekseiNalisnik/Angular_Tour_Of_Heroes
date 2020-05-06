import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Product } from '../interfaces/product';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private productsUrl = 'api/products';  // URL to web api
  private basketUrl = 'api/basket';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productsUrl);
  }

  getBasketProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.basketUrl);
  }

  postProduct(product): Observable<Product> {
    return this.http.post<Product>(this.basketUrl, product);
  }

  deleteBasketProduct(productId: number): Observable<Product> {
    return this.http.delete<Product>(this.basketUrl + `/${productId}`);
  }
}