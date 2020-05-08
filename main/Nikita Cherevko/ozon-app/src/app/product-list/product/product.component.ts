import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../interfaces/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  products: Product[];

  backgroundColorSwitch = false;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.productService
      .getProducts()
      .subscribe((products) => (this.products = products));
  }

  addProductToCart(product) {
    this.productService
      .postCartProduct(product)
      .subscribe((product) => console.log('Product - ', product));

    this.backgroundColorSwitch = true;
  }
}
