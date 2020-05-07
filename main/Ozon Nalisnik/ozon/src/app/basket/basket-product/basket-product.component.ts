import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { Product } from '../../interfaces/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-basket-product',
  templateUrl: './basket-product.component.html',
  styleUrls: ['./basket-product.component.css']
})
export class BasketProductComponent implements OnInit {
  @Output() productsForOutput: EventEmitter<Product[]> = new EventEmitter<Product[]>();
  basketProducts: Product[] = [];
  masterSelected: boolean = false;
  // selectedQuantityValue: string = 'AAAA';

  constructor(
    private productService: ProductService
  ) { }

  ngOnInit(): void {
    this.getAllBasketProducts();
    this.productsForOutput.emit(this.basketProducts);
  }

  getAllBasketProducts(): void {
    this.productService.getBasketProducts()
      .subscribe(products => {
        this.basketProducts = products;
        this.productsForOutput.emit(this.basketProducts);
      });
  }

  deleteProductFromBasket(product) {
    const productId = product.id;
    console.log('productId in BASKET delete - ', productId);
    this.productService.deleteBasketProduct(productId)
      .subscribe(() => {
        this.basketProducts = this.basketProducts.filter(
          product => product.id !== productId
        );
        this.productsForOutput.emit(this.basketProducts);
      });
  }

  deleteCheckedProductsFromBasket() {
    for(let i = 0; i < this.basketProducts.length; i++) {
      if(this.basketProducts[i].isSelected == true) {
        this.deleteProductFromBasket(this.basketProducts[i]);
      }
    }
  }

  checkUncheckAll() {
    for(let i = 0; i < this.basketProducts.length; i++) {
      this.basketProducts[i].isSelected = this.masterSelected;
    }
  }

  isAllSelected() {
    this.masterSelected = this.basketProducts.every(function(product: any) {
        return product.isSelected == true;
    });
  }
}
