import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { Product } from '../../interfaces/product';
import { ProductService } from '../../services/product.service';
import { BasketLenghtService } from '../../services/basket-lenght.service';
@Component({
  selector: 'app-main-product',
  templateUrl: './main-product.component.html',
  styleUrls: ['./main-product.component.css']
})
export class MainProductComponent implements OnInit {
  backgroundSwitch: boolean = false;
  @Input() basketProducts: Product[] = [];
  @Input() product: Product;
  @Output() productsForOutput: EventEmitter<Product> = new EventEmitter<Product>();

  constructor(
    private productService: ProductService,
    private basketLenghtService: BasketLenghtService
  ) { }

  ngOnInit(): void {
    this.backgroundSwitch = this.isProductInBasket(this.product);
    console.log('this.backgroundSwitch - ', this.backgroundSwitch);
  }

  toggleFlag() {
    this.backgroundSwitch = true;
  }

  addProductToBasket(product) {
    this.productsForOutput.emit(product);
    this.toggleFlag();
  }

  isProductInBasket(product: Product): boolean {
    for(let i = 0; i < this.basketProducts.length; i++) {
      if(this.basketProducts[i].id === product.id) {
        return true;
      }
    }
    return false;
  }
}