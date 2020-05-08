import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/interfaces/product';
import { ObservableService } from 'src/app/services/observable.service';

@Component({
  selector: 'app-cart-product',
  templateUrl: './cart-product.component.html',
  styleUrls: ['./cart-product.component.css'],
})
export class CartProductComponent implements OnInit {
  @Output() outputProducts: EventEmitter<Product[]> = new EventEmitter<
    Product[]
  >();

  masterSelected = false;
  products: Product[] = [];

  constructor(
    private productService: ProductService,
    private observableService: ObservableService) {}

  ngOnInit(): void {
    this.getProducts();
    this.outputProducts.emit(this.products);
    console.log('Products recieved');
    this.observableService.addToHeader(this.products)
  }

  getProducts() {
    this.productService.getCartProducts().subscribe((products) => {
      this.products = products;
      this.outputProducts.emit(this.products);
      this.observableService.addToHeader(this.products);
    });
  }

  removeProductFromCart(product) {
    const productId = product.id;
    this.productService.deleteCartProduct(product.id).subscribe(() => {
      this.products = this.products.filter(
        (product) => productId !== product.id
      );
      this.outputProducts.emit(this.products);
      this.observableService.addToHeader(this.products);
    });
  }

  removeChecked() {
    for (const product of this.products) {
      if (product.isSelected === true) {
        this.removeProductFromCart(product);
      }
    }
    this.observableService.addToHeader(this.products);
  }

  checkUncheckAll() {
    for (const product of this.products) {
      product.isSelected = this.masterSelected;
    }
  }

  isAllSelected() {
    this.masterSelected = this.products.every(
      (product) => product.isSelected === true
    );
  }
}
