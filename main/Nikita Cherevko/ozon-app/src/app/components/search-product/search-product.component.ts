import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../shared/services/product.service';
import { Product } from '../../shared/interfaces/product';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-search-product',
  templateUrl: './search-product.component.html',
  styleUrls: ['./search-product.component.css'],
})
export class SearchProductComponent implements OnInit {
  products: Product[];
  private searchTerms = new Subject<string>();
  searchProduct: string = '';
  showDropDown: boolean = false;

  constructor(private productService: ProductService) {}

  search(term: string): void {
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    this.getProducts();
  }

  ngDoCheck() {
    // console.log('flag', this.showDropDown);
  }

  getProducts() {
    this.productService
      .getProducts()
      .subscribe((products) => (this.products = products));
  }

  selectProduct(product) {
    this.searchProduct = product.name;
    this.showDropDown = false;
  }

  closeDropDown() {
    // this.showDropDown = !this.showDropDown;
    this.showDropDown = false;
  }

  openDropDown() {
    this.showDropDown = true;
  }
}
