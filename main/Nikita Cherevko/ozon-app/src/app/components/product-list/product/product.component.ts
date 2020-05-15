import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Product } from 'src/app/shared/interfaces/product';
import { CartProduct } from 'src/app/shared/interfaces/cartProduct';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  @Input() isProductInCart;
  @Input() cartProduct:CartProduct;
  @Output() outputProducts: EventEmitter<Product> = new EventEmitter<Product>();

  backgroundColorSwitch = false;

  constructor() {}

  ngOnInit(): void {}

  addProductToCart(cartProduct) {
    // console.log('this cart prodcuts', this.cartProducts);
    this.cartProduct.quantity = 1;
    this.outputProducts.emit(cartProduct);
  }
}
