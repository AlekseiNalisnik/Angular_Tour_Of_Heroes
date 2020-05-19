import { Component, OnInit, Input } from '@angular/core';

// import { Product } from '../interfaces/product';
import { BasketProduct } from '../../shared/interfaces/basketProduct';
import { EventBusService } from '../../shared/services/event-bus.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  basketProducts: BasketProduct[] = [];
  toggleFlag: boolean = false;
  authFlag: boolean = false;
  responseStatusFlag: boolean = false;

  searchProduct: string = '';
  showDropDown: boolean = false;

  constructor(
    private eventBusService: EventBusService,
    private router: Router
    ) { }

  ngOnInit(): void {

  }

  ngDoCheck(): void {
    this.eventBusService.currentData.subscribe(p => this.basketProducts = p);
    console.log('Это флаг со статусом от POST запроса при авторизации - ', this.responseStatusFlag);
  }

  selectAuthorizationStatus(authorizationStatusFlag) {
    this.responseStatusFlag = authorizationStatusFlag;
    // console.log('Это флаг со статусом от POST запроса при авторизации - ', this.responseStatusFlag);
    if(this.responseStatusFlag == true) {
      this.authFlag = !this.authFlag;
      this.router.navigate(['userProfile']);
      // this.router.navigate(['profile', 3], {queryParams: {id: 3}, fragment: 'address'});
    }
  }

  toggleToReg() {
    if(this.responseStatusFlag == true) {
      return;
    }
    this.toggleFlag = !this.toggleFlag;
  }

  stayOnReg(e) {
    event.stopPropagation();
  }

  toggleAuthFlag(flagAuthFromReg?) {
    if(this.responseStatusFlag == true) {
      return;
    }
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
