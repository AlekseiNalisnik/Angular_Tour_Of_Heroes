import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { ObservableService } from 'src/app/services/observable.service';
import { Product } from 'src/app/interfaces/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  @Input() cartProducts: Product[] = [];
  @Input() product;
  @Output() outputProducts: EventEmitter<Product> = new EventEmitter<Product>();

  backgroundColorSwitch = false;

  constructor(
    private productService: ProductService,
    private observableService: ObservableService
  ) {}

  ngOnInit(): void {
    this.backgroundColorSwitch = this.isProductInCart(this.product);
    console.log('this.backgroundSwitch - ', this.backgroundColorSwitch);
  }

  addProductToCart(product) {
    this.outputProducts.emit(product);
    this.backgroundColorSwitch = true;
  }

  isProductInCart(product: Product): boolean {
    for(let i = 0; i < this.cartProducts.length; i++) {
      if(this.cartProducts[i].id === product.id) {
        return true;
      }
    }
    return false;
  }

}
