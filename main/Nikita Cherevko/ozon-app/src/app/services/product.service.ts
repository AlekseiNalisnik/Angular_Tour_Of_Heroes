import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from '../interfaces/product';
import { HttpClient } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  products: Product[];

  private productsUrl = 'api/products';
  private cartUrl = 'api/cart';

  constructor(private http: HttpClient) {}

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

  putCartProduct(product: Product): Observable<Product> {
    console.log(product)
    return this.http.put<Product>(this.cartUrl, product);
  }

  /* GET products whose name contains search term */
  searchProducts(term: string): Observable<Product[]> {
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return of([]);
    }
    return this.http
      .get<Product[]>(`${this.productsUrl}/?name=${term}`)
      .pipe(catchError(this.handleError<Product[]>('searchProdcuts', [])));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    };
  }
}