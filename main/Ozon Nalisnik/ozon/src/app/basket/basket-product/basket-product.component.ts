import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { Product } from '../../interfaces/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-basket-product',
  templateUrl: './basket-product.component.html',
  styleUrls: ['./basket-product.component.css']
})
export class BasketProductComponent implements OnInit {
  // @Output() productsForOutput: EventEmitter<Product[]> = new EventEmitter<Product[]>();
  basketProducts: Product[] = [];

  constructor(
    private productService: ProductService
  ) { }

  ngOnInit(): void {
    this.getAllBasketProducts();
    // this.productsForOutput.emit(this.basketProducts);
  }

  getAllBasketProducts(): void {
    this.productService.getBasketProducts()
      .subscribe(products => this.basketProducts = products);
  }

  deleteProductFromBasket(product) {
    const productId = product.id;
    console.log('productId in BASKET delete - ', productId);
    this.productService.deleteBasketProduct(productId)
      .subscribe(() => {
        this.basketProducts = this.basketProducts.filter(
          product => product.id !== productId
        );
      });
  }

  deleteCheckedProductsFromBasket() {

  }

  checkAllProductsInBasket() {
    
  }

}
