import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @Output() toggleHeaderFlagFromAuthToReg: EventEmitter<boolean> = new EventEmitter<boolean>();
  toggleToReg = false;
  constructor() { }

  ngOnInit(): void {
  }

  openReg() {
    this.toggleToReg = !this.toggleToReg;
    this.toggleHeaderFlagFromAuthToReg.emit(this.toggleToReg);
  }

}
