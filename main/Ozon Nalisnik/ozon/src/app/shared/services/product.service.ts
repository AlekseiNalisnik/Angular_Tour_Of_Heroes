import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Product } from '../interfaces/product';
import { BasketProduct } from '../interfaces/basketProduct';
import { HttpClient, HttpParams } from '@angular/common/http';

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

  getProductById(id: string){
    return this.http.get(this.productsUrl, {
      params: new HttpParams().set(`id`, id)
    });
  }

  getBasketProducts(): Observable<BasketProduct[]> {
    return this.http.get<BasketProduct[]>(this.basketUrl);
  }

  postProduct(basketProduct: BasketProduct): Observable<BasketProduct> {
    return this.http.post<BasketProduct>(this.basketUrl, basketProduct);
  }

  deleteBasketProduct(basketProductId: number): Observable<BasketProduct> {
    return this.http.delete<BasketProduct>(this.basketUrl + `/${basketProductId}`);
  }

  updateBasketProduct(basketProduct: BasketProduct): Observable<BasketProduct> {
    return this.http.put<BasketProduct>(this.basketUrl, basketProduct);
  }

  getBasketProductById(id: string){
    return this.http.get(this.basketUrl, {
      params: new HttpParams().set(`id`, id)
    });
  }
}