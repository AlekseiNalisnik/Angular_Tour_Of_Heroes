import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { ProductService } from '../services/product.service';
import { Product } from '../interfaces/product';
import {MaindbService} from '../services/maindb.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css'],
})
export class ProductPageComponent implements OnInit {

  product: Product;
  buttonColor: string;
  selectedItem: string;
  backgroundSwitch: boolean = false;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private maindb: MaindbService) { }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      console.log(params);
      this.product = this.maindb.getProductById(+params.id);
    });
  }

  addProductToCart(product) {
    this.productService
      .postCartProduct(product)
      .subscribe((product) => console.log('Product - ', product));
      this.backgroundSwitch = true;
  }

  activeNow(item: string) {
    this.selectedItem = item;
  }

}
