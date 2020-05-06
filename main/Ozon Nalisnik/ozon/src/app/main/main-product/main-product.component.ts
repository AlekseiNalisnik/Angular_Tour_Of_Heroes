import { Component, OnInit, ElementRef } from '@angular/core';

import { Product } from '../../interfaces/product';
import { ProductService } from '../../services/product.service';
import { InMemoryDataService } from '../../services/in-memory-data.service';

@Component({
  selector: 'app-main-product',
  templateUrl: './main-product.component.html',
  styleUrls: ['./main-product.component.css']
})
export class MainProductComponent implements OnInit {
  products: Product[];
  // backgroundSwitch: boolean = false;

  constructor(
    private productService: ProductService,
    private el: ElementRef
  ) { }

  ngOnInit(): void {
    this.getAllProducts();
    console.log(this.el.nativeElement);
  }

  getAllProducts(): void {
    this.productService.getProducts()
      .subscribe(products => this.products = products);
  }

  addProductToBasket(product) {
    this.productService.postProduct(product)
      .subscribe(product => console.log('PRODUCT - ', product));
  }
}