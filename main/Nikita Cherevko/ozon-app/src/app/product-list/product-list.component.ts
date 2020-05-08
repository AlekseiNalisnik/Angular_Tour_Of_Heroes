import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../interfaces/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  products: Product[];
  constructor() {}

  ngOnInit(): void {}
}
