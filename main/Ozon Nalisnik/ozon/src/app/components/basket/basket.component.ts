import { Component, OnInit, ViewChild } from '@angular/core';

// import { Product } from '../../shared/interfaces/product';
import { BasketProduct } from '../../shared/interfaces/basketProduct';
import { ProductService } from '../../shared/services/product.service';
import { EventBusService } from '../../shared/services/event-bus.service';
// import { BasketOrderPanelComponent } from './basket-order-panel/basket-order-panel.component';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  basketProducts: BasketProduct[] = [];
  masterSelected: boolean = false;
  // @ViewChild(BasketOrderPanelComponent) basketOrderPanelComponent: BasketOrderPanelComponent;

  constructor(
    private productService: ProductService,
    private eventBusService: EventBusService
  ) { }

  ngOnInit(): void {
    this.getAllBasketProducts();
  }

  onBasketChange(basketProducts) {
    this.basketProducts = basketProducts;
  }

  getAllBasketProducts(): void {
    this.productService.getBasketProducts()
      .subscribe(products => {
        this.basketProducts = products;
        this.eventBusService.changeData(this.basketProducts);
      });
  }

  deleteProductFromBasket(product) {
    const productId = product.id;
    this.productService.deleteBasketProduct(productId)
    .subscribe(() => {
      this.basketProducts = this.basketProducts.filter(
        product => product.id !== productId
      );
      // this.basketOrderPanelComponent.getTotalValuesIfProducsInBasket();
      this.eventBusService.changeData(this.basketProducts);
    });
  }

  deleteCheckedProductsFromBasket() {
    for(let i = 0; i < this.basketProducts.length; i++) {
      if(this.basketProducts[i].isSelected == true) {
        this.deleteProductFromBasket(this.basketProducts[i]);
      }
    }
    // this.basketOrderPanelComponent.getTotalValuesIfProducsInBasket();
    this.eventBusService.changeData(this.basketProducts);
  }

  checkUncheckAll() {
    for(let i = 0; i < this.basketProducts.length; i++) {
      this.basketProducts[i].isSelected = this.masterSelected;
    }
    // this.basketOrderPanelComponent.getTotalValuesIfProducsInBasket();
    this.eventBusService.changeData(this.basketProducts);
  }

  changeMasterSelected(masterSelected) {
    this.masterSelected = masterSelected;
    // this.basketOrderPanelComponent.getTotalValuesIfProducsInBasket();
  }

  putProductQuantityToBasket(product) {
    this.productService.updateBasketProduct(product)
    .subscribe(res => console.log('RES PUT - ', res));
  }
}
