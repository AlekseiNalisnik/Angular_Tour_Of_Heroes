import { Component, OnInit, Input } from '@angular/core';

// import { RegistrationComponent } from '../registration/registration.component';
// import { Router } from '@angular/router';

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
  }

  stayOnReg(e) {
    event.stopPropagation();
  }

  toggleAuthFlag(flagAuthFromReg?) {
    if(flagAuthFromReg) this.toggleToReg();
    this.authFlag = !this.authFlag;
  }
}
