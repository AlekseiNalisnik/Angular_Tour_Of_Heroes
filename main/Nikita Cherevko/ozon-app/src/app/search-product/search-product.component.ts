import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../interfaces/product';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-search-product',
  templateUrl: './search-product.component.html',
  styleUrls: ['./search-product.component.css']
})
export class SearchProductComponent implements OnInit {
  products$: Observable<Product[]>;
  private searchTerms = new Subject<string>();

  constructor(private productService: ProductService) { }

  search(term: string): void {
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    this.products$ = this.searchTerms.pipe(
            // wait 300ms after each keystroke before considering the term
            debounceTime(300),

            // ignore new term if same as previous term
            distinctUntilChanged(),
      
            // switch to new search observable each time the term changes
            switchMap((term: string) => this.productService.searchProducts(term)),
    );
  }
}
