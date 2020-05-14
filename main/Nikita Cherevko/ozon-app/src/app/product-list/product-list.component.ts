import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../interfaces/product';
import { EventBusService } from '../services/event-bus.service';
import { CartProduct } from '../interfaces/cartProduct';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  cartProducts: CartProduct[] = [];
  products: Product[];
  constructor(
    private productService: ProductService,
    private eventBusService: EventBusService
  ) {}

  ngOnInit(): void {
    this.getProducts();
    this.getCartProduts();
    // console.log('ng on init cartProducts -', this.cartProducts);
  }

  getCartProduts() {
    this.productService.getCartProducts().subscribe((cartProducts) => {
      this.cartProducts = cartProducts;
      // console.log('ng on init cartProducts -', this.cartProducts);
    });
  }

  getProducts(): void {
    this.productService
      .getProducts()
      .subscribe((products) => (this.products = products));
  }

  AddProductToCart(cartProduct) {
    this.productService.postCartProduct(cartProduct).subscribe((productAss) => {
      if (productAss == null) {
        // console.log('Product == 0', product);
        return;
      } else this.cartProducts.push(cartProduct);
      this.eventBusService.changeData(this.cartProducts);
    });
  }

  isProductInCart(cartProduct): boolean {
    for (let i = 0; i < this.cartProducts.length; i++) {
      if (this.cartProducts[i].id === cartProduct.id) {
        return true;
      }
    }
    // console.log(this.cartProducts);
    return false;
  }
}
