import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import {Product} from '../interfaces/product';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  products: Product[];

  private productsUrl = 'api/products';
  private cartUrl = 'api/cart';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productsUrl);
  }

  getCartProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.cartUrl);
  }

  deleteCartProduct(id: number): Observable<Product> {
    return this.http.delete<Product>(this.cartUrl + `/${id}`);
  }

  postCartProduct(product): Observable<Product> {
    return this.http.post<Product>(this.cartUrl, product);
  }

}
