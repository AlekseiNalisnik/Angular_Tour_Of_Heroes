import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

import { Product } from '../../interfaces/product';
import { ProductService } from '../../services/product.service';
import { BasketLenghtService } from '../../services/basket-lenght.service';

@Component({
  selector: 'app-basket-product',
  templateUrl: './basket-product.component.html',
  styleUrls: ['./basket-product.component.css']
})
export class BasketProductComponent implements OnInit {
  @Output() singleProductForOutput: EventEmitter<Product> = new EventEmitter<Product>();
  @Input() product: Product;
  @Input() masterSelected;
  basketProducts: Product[] = [];

  constructor() { }

  ngOnInit(): void {

  }

  deleteProductFromBasket(product) {
    this.singleProductForOutput.emit(product);
  }

  isAllSelected() {
    this.masterSelected = this.basketProducts.every(function(product: Product) {
      return product.isSelected == true;
    });
  }
}
