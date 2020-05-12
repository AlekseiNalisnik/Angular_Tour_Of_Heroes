import { Component, OnInit, Input } from '@angular/core';

import { BasketLenghtService } from '../services/basket-lenght.service';
import { Product } from '../interfaces/product';

// import { RegistrationComponent } from '../registration/registration.component';
// import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  basketProducts: Product[] = [];
  toggleFlag: boolean = false;
  authFlag: boolean = false;

  constructor(private basketLenghtService: BasketLenghtService) { }

  ngOnInit(): void {

  }

  ngDoCheck(): void {
    this.basketProducts = this.basketLenghtService.basketProducts;
    // console.log('ngDoCheck - ', this.basketProducts);
  }

  toggleToReg() {
    this.toggleFlag = !this.toggleFlag;
  }

  stayOnReg(e) {
    event.stopPropagation();
  }

  toggleAuthFlag(flagAuthFromReg?) {
    if(flagAuthFromReg) this.toggleToReg();
    this.authFlag = !this.authFlag;
  }
}
