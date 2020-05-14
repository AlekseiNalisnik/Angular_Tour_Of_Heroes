import { Component, OnInit } from '@angular/core';
import { Product } from '../interfaces/product';
import { EventBusService } from '../services/event-bus.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  toggleFlag = false;
  authFlag = false;
  products: Product[] = [];

  constructor(private eventBusService: EventBusService) { }

  ngOnInit(): void {

  }

  ngDoCheck(): void {
    this.eventBusService.currentData.subscribe(products => this.products = products); 
    // console.log('ngDoCheck - ', this.products);
 }

  toggleToReg() {
    this.toggleFlag = !this.toggleFlag;
    // console.log('this.authFlag - ', this.authFlag);
    // this.authFlag = flagAuthFromReg;
  }

  stayOnReg(e) {
    event.stopPropagation();
  }

  toggleAuthFlag(flagAuthFromReg?) {
    if (flagAuthFromReg) {
       this.toggleToReg(); 
      }
    // this.authFlag = !this.authFlag;
    // console.log('this.authFlag 2 - ', this.authFlag);
    // console.log('flagAuthFromReg', flagAuthFromReg);
  }

}
