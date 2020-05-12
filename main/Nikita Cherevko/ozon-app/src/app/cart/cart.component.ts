import { Component, OnInit } from '@angular/core';
import { Product } from '../interfaces/product';
import { ProductService } from '../services/product.service';
import { ObservableService } from '../services/observable.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  products: Product[] = [];
  masterSelected: boolean = false;

  constructor(
    private productService: ProductService,
    private observableService: ObservableService
  ) {}

  ngOnInit(): void {
    this.getCartProducts();
  }

  onBasketChange(basketProducts) {
    this.products = basketProducts;
  }

  getCartProducts(): void {
    this.productService.getCartProducts().subscribe((products) => {
      this.products = products;
      this.observableService.addToHeader(this.products);
    });
  }

  deleteProductFromCart(product) {
    const productId = product.id;
    this.productService.deleteCartProduct(productId).subscribe(() => {
      this.products = this.products.filter(
        (product) => product.id !== productId
      );
      this.observableService.addToHeader(this.products);
    });
  }

  deleteCheckedProductsFromCart() {
    for (let i = 0; i < this.products.length; i++) {
      if (this.products[i].isSelected == true) {
        this.deleteProductFromCart(this.products[i]);
      }
    }
    this.observableService.addToHeader(this.products);
  }

  checkUncheckAll() {
    for (let i = 0; i < this.products.length; i++) {
      this.products[i].isSelected = this.masterSelected;
    }
    this.observableService.addToHeader(this.products);
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
