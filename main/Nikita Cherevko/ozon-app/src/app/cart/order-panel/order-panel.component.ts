import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { CartProduct } from 'src/app/interfaces/cartProduct';

@Component({
  selector: 'app-order-panel',
  templateUrl: './order-panel.component.html',
  styleUrls: ['./order-panel.component.css'],
})
export class OrderPanelComponent implements OnInit {
  @Input() cartProducts: CartProduct[];

  productsWeight = 0;
  productWeight = 0;
  productsSumValue = 0;
  productSumValue = 0;
  quantitySumValue = 0;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    // this.productService
    //   .getCartProducts()
    //   .subscribe((products) => (this.cartProducts = products));
  }

  weightSum() {
    this.productsWeight = 0;
    for (const product of this.cartProducts) {
      this.productWeight = product.weight * product.quantity;
      this.productsWeight += this.productWeight;
    }
    return this.productsWeight;
  }

  valueSum() {
    this.productsSumValue = 0;
    for (const product of this.cartProducts) {
      this.productSumValue = product.value * product.quantity;
      this.productsSumValue += this.productSumValue;
    }
    return this.productsSumValue;
  }

  Reload() {
    location.reload();
  }

  quantitySum() {
    this.quantitySumValue = 0;
    for (const product of this.cartProducts) {
      this.quantitySumValue += +product.quantity;
    }
    return this.quantitySumValue;
  }
}
