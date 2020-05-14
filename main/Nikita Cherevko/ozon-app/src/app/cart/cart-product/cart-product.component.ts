import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/interfaces/product';
import { CartProduct } from 'src/app/interfaces/cartProduct';

@Component({
  selector: 'app-cart-product',
  templateUrl: './cart-product.component.html',
  styleUrls: ['./cart-product.component.css'],
})
export class CartProductComponent implements OnInit {
  @Output() singleProductForOutput: EventEmitter<Product> = new EventEmitter<
    Product
  >();
  @Output() changeQuantityOutput: EventEmitter<Product> = new EventEmitter<Product>();
  @Input() cartProduct: CartProduct;
  @Input() masterSelected;
  cartProducts: CartProduct[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {}

  deleteProductFromCart(product) {
    this.singleProductForOutput.emit(product);
  }

  isAllSelected() {
    this.masterSelected = this.cartProducts.every(function (
      product: CartProduct
    ) {
      return product.isSelected == true;
    });
  }

  changeQuantity(quantity) {
    this.cartProduct.quantity = quantity;
    this.changeQuantityOutput.emit(this.cartProduct);

    console.log(quantity, 'QUANTITY CHANGED');
  }
}
