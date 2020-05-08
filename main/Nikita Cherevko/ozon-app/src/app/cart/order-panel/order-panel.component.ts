import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/interfaces/product';

@Component({
  selector: 'app-order-panel',
  templateUrl: './order-panel.component.html',
  styleUrls: ['./order-panel.component.css'],
})
export class OrderPanelComponent implements OnInit {

  @Input() products;

  productsWeight = 0;
  productsSumValue = 0;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService
      .getCartProducts()
      .subscribe((products) => (this.products = products));
  }

  weightSum() {
    this.productsWeight = 0;
    for (const product of this.products) {
      this.productsWeight += product.weight;
    }
    return this.productsWeight;
  }

  valueSum() {
    this.productsSumValue = 0;
    for (const product of this.products) {
      this.productsSumValue += product.value;
    }
    return this.productsSumValue;
  }

  Reload() {
    location.reload();
  }

}
