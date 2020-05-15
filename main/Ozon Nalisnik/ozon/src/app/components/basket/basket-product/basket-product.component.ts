import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

import { Product } from '../../../shared/interfaces/product';
import { BasketProduct } from '../../../shared/interfaces/basketProduct';
import { ProductService } from '../../../shared/services/product.service';

@Component({
  selector: 'app-basket-product',
  templateUrl: './basket-product.component.html',
  styleUrls: ['./basket-product.component.css']
})
export class BasketProductComponent implements OnInit {
  @Output() deleteBasketProductForOutput: EventEmitter<BasketProduct> = new EventEmitter<BasketProduct>();
  @Output() changedProductQuantityForOutput: EventEmitter<BasketProduct> = new EventEmitter<BasketProduct>();
  @Input() basketProduct: BasketProduct;
  @Input() masterSelected;
  basketProducts: BasketProduct[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {

  }

  deleteProductFromBasket(basketProduct) {
    this.deleteBasketProductForOutput.emit(basketProduct);
  }

  isAllSelected() {
    this.masterSelected = this.basketProducts.every(
      function(basketProduct: BasketProduct) {
        return basketProduct.isSelected == true;
      }
    );
  }

  changeBasketProductQuantity(quantity) {
    this.basketProduct.quantity = quantity;
    this.changedProductQuantityForOutput.emit(this.basketProduct);
  }
}
