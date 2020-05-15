import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from 'src/app/shared/services/product.service';
import { EventBusService } from 'src/app/shared/services/event-bus.service';
import { Product } from 'src/app/shared/interfaces/product';
import { CartProduct } from 'src/app/shared/interfaces/cartProduct';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { query } from '@angular/animations';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  cartProducts: CartProduct[] = [];
  products: Product[];
  searchProducts: Product[] = [];
  constructor(
    private productService: ProductService,
    private eventBusService: EventBusService,
    private route: ActivatedRoute,
    private simpleRoute: Router
  ) {}

  text: string;
  currentUrl: string = "";

  ngOnInit(): void {
    this.getProducts();
    this.getCartProduts();
    // console.log('ng on init cartProducts -', this.cartProducts);
    this.getQueryParams();
    this.changeSearchStateByTracking();
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

  getSearchProducts() {
    this.productService
      .getProductsByName(this.text)
      .subscribe((searchProducts) => {
        this.searchProducts = searchProducts;
        if (this.currentUrl.includes('text')) {
          this.products = this.searchProducts;
        }     
        else {
          this.getProducts();
          // console.log('else products');
        }
      });
  }

  getQueryParams() {
    this.route.queryParams.subscribe((queryParam) => {
      this.text = queryParam['text'];
    });
  }

  changeSearchStateByTracking() {
    this.simpleRoute.events.subscribe(tracker => {
      if(tracker instanceof NavigationEnd) {
        this.currentUrl = tracker.url;
        this.getSearchProducts();
      }
    });
  }



}
