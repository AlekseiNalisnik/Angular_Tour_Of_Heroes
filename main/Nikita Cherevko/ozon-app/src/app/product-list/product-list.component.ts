import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../interfaces/product';
import { ObservableService } from '../services/observable.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  cartProducts: Product[] = [];
  products: Product[];
  constructor(
    private productService: ProductService,
    private observableService: ObservableService
    ) {}

  ngOnInit(): void {
    this.getProducts();
    this.cartProducts =  this.observableService.lastProducts;
    console.log('cartProducts -', this.cartProducts)
  }

  getProducts(): void {
    this.productService
      .getProducts()
      .subscribe((products) => (this.products = products));
  }

 AddProductToCart(product) {
  this.productService.postCartProduct(product).subscribe((productAss) => {
    if(productAss == null) {
      console.log('Product == 0', product);
      return;
    }
    else this.cartProducts.push(product);
    this.observableService.addToHeader(this.cartProducts);
  });
 }

 isProductInCart(product: Product): boolean {
  for(let i = 0; i < this.cartProducts.length; i++) {
    if(this.cartProducts[i].id === product.id) {
      return false;
    }
  }
  return true;
}

}
