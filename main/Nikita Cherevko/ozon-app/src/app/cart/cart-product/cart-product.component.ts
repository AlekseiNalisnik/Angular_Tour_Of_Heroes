import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/interfaces/product';
import { ObservableService } from 'src/app/services/observable.service';

@Component({
  selector: 'app-cart-product',
  templateUrl: './cart-product.component.html',
  styleUrls: ['./cart-product.component.css'],
})
export class CartProductComponent implements OnInit {
  @Output() singleProductForOutput: EventEmitter<Product> = new EventEmitter<Product>();
  @Output() quantityOutput: EventEmitter<number> = new EventEmitter<number>();
  @Input() product: Product;
  @Input() masterSelected;
  basketProducts: Product[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {

  }

  deleteProductFromCart(product) {
    this.singleProductForOutput.emit(product);
  }

  isAllSelected() {
    this.masterSelected = this.basketProducts.every(function(product: Product) {
      return product.isSelected == true;
    });
  }

  changeQuantity(quantity) {
    this.product.quantity = quantity;
    this.singleProductForOutput.emit(this.product)
    this.productService
    .putCartProduct(this.product)
    .subscribe((response) => {
      console.log(response);
    });

    console.log(quantity, 'QUANTITY CHANGED')
  }

}
