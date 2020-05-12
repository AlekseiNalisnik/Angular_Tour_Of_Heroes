import { Component, OnInit } from '@angular/core';
import { ObservableService } from '../services/observable.service';
import { Product } from '../interfaces/product';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  toggleFlag = false;
  authFlag = false;
  products: Product[] = [];

  constructor(private observableService: ObservableService) { }

  ngOnInit(): void {

  }

  ngDoCheck(): void {
    this.products = this.observableService.lastProducts;
    //  console.log('ngDoCheck - ', this.products);
 }

  toggleToReg() {
    this.toggleFlag = !this.toggleFlag;
    console.log('this.authFlag - ', this.authFlag);
    // this.authFlag = flagAuthFromReg;
  }

  stayOnReg(e) {
    event.stopPropagation();
  }

  toggleAuthFlag(flagAuthFromReg?) {
    if (flagAuthFromReg) {
       this.toggleToReg(); 
      }
    this.authFlag = !this.authFlag;
    console.log('this.authFlag 2 - ', this.authFlag);
    console.log('flagAuthFromReg', flagAuthFromReg);
  }

}
