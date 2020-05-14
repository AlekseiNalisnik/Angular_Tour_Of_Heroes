import { Component, OnInit, Input } from '@angular/core';

// import { Product } from '../interfaces/product';
import { BasketProduct } from '../shared/interfaces/basketProduct';
import { EventBusService } from '../services/event-bus.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  basketProducts: BasketProduct[] = [];
  toggleFlag: boolean = false;
  authFlag: boolean = false;

  searchProduct: string = '';
  showDropDown: boolean = false;

  constructor(private eventBusService: EventBusService) { }

  ngOnInit(): void {

  }

  ngDoCheck(): void {
    this.eventBusService.currentData.subscribe(p => this.basketProducts = p);
  }

  toggleToReg() {
    this.toggleFlag = false;
  }

  stayOnReg(e) {
    event.stopPropagation();
  }

  toggleAuthFlag(flagAuthFromReg?) {
    if(flagAuthFromReg) this.toggleToReg();
    this.authFlag = !this.authFlag;
  }

  selectBaskeProduct(basketProduct) {
    this.searchProduct = basketProduct.description;
    this.showDropDown = false;
  }

  closeDropDown() {
    // this.showDropDown = !this.showDropDown;
    this.showDropDown = false;
  }

  openDropDown() {
    this.showDropDown = true;
  }
}
