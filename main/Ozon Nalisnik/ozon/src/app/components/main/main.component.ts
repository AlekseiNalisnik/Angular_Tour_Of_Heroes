import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';

import { Product } from '../../shared/interfaces/product';
import { BasketProduct } from '../../shared/interfaces/basketProduct';
import { ProductService } from '../../shared/services/product.service';
import { EventBusService } from '../../shared/services/event-bus.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  searchedProducts: Product[] = [];
  products: Product[] = [];
  basketProducts: BasketProduct[] = [];
  text: string;
  currentUrl: string = '';

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private eventBusService: EventBusService,
    private tractor: Router
  ) { }

  ngOnInit(): void {
    this.getAllProducts();
    this.getQueryParameters();
    this.getAllBasketProducts();
    this.changeSearchedStateByTrackingUrl();
  }

  getAllProducts(): void {
    this.productService.getProducts()
      .subscribe(products => {
        this.products = products;
      });
  }

  getAllBasketProducts(): void {
    this.productService.getBasketProducts()
    .subscribe(basketProducts => {
      this.basketProducts = basketProducts;
    });
  }

  addProductToBasket(product) {
    this.productService.postProduct(product)
      .subscribe((p) => {
        if(p === null) {
          return;
        } else {
          this.basketProducts.push(product);
        }
        this.eventBusService.changeData(this.basketProducts);
      });
  }

  isProductInBasket(product): boolean {
    for(let i = 0; i < this.basketProducts.length; i++) {
      if(this.basketProducts[i].id === product.id) {
        return true;
      }
    }
    return false;
  }

  changeSearchedStateByTrackingUrl() {
    this.tractor.events.subscribe(exTractor => {
      if(exTractor instanceof NavigationEnd){
        this.currentUrl = exTractor.url;
        this.getSearchedProducts();
      }
    })
  }

  getQueryParameters() {
    this.route.queryParams.subscribe(
      (queryParam: any) => {
          this.text = queryParam['text'];
      }
    );
  }

  getSearchedProducts() {
    this.productService.getProductByName(this.text)
    .subscribe(res => {
      this.searchedProducts = res;
      if(this.currentUrl.includes('text')) {
        this.products = this.searchedProducts;
      } else {
        this.getAllProducts();
      }
    });
  }
}
