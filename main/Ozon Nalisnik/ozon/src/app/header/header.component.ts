import { Component, OnInit, Input } from '@angular/core';

import { RegistrationComponent } from '../registration/registration.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  toggleFlag: boolean = false;
  authFlag: boolean = false;

  constructor() { }

  ngOnInit(): void {
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
    if(flagAuthFromReg) this.toggleToReg();
    this.authFlag = !this.authFlag;
    console.log('this.authFlag 2 - ', this.authFlag);
    console.log('flagAuthFromReg', flagAuthFromReg);
  }
}
