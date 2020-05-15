import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/interfaces/product';
import { CartProduct } from 'src/app/shared/interfaces/cartProduct';
import { ProductService } from 'src/app/shared/services/product.service';
import { EventBusService } from 'src/app/shared/services/event-bus.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  products: Product[] = [];
  cartProducts: CartProduct[] = [];
  masterSelected: boolean = false;

  constructor(
    private productService: ProductService,
    private eventBusService: EventBusService
  ) {}

  ngOnInit(): void {
    this.getCartProducts();
  }

  // onCartChange(cartProducts) {
  //   this.products = cartProducts;
  // }

  getCartProducts(): void {
    this.productService.getCartProducts().subscribe((cartProducts) => {
      this.cartProducts = cartProducts;
      this.eventBusService.changeData(this.cartProducts);
    });
  }

  deleteProductFromCart(product) {
    const productId = product.id;
    this.productService.deleteCartProduct(productId).subscribe(() => {
      this.cartProducts = this.cartProducts.filter(
        (product) => product.id !== productId
      );
      this.eventBusService.changeData(this.cartProducts);
    });
  }

  deleteCheckedProductsFromCart() {
    for (let i = 0; i < this.cartProducts.length; i++) {
      if (this.cartProducts[i].isSelected == true) {
        this.deleteProductFromCart(this.cartProducts[i]);
      }
    }
    this.eventBusService.changeData(this.cartProducts);
  }

  checkUncheckAll() {
    for (let i = 0; i < this.cartProducts.length; i++) {
      this.cartProducts[i].isSelected = this.masterSelected;
    }
    this.eventBusService.changeData(this.cartProducts);
  }

  changeMasterSelected(masterSelected) {
    console.log('masterSelected - ', masterSelected);
    this.masterSelected = masterSelected;
  }

  ChangeQuantity(product) {
    this.productService
      .putCartProduct(product)
      .subscribe((resolve) => console.log(resolve));
  }
}
