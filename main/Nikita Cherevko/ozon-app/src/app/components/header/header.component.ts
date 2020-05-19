import { Component, OnInit } from '@angular/core';
import { EventBusService } from '../../shared/services/event-bus.service';
import { Product } from 'src/app/shared/interfaces/product';

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
}

 stayOnReg(e) {
  event.stopPropagation();
 }

 toggleAuthFlag(flagAuthFromReg?) {
  if(flagAuthFromReg) this.toggleToReg();
  this.authFlag = !this.authFlag;
 }

}
