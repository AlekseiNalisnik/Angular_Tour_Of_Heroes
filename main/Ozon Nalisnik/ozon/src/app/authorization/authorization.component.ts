import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css']
})
export class AuthorizationComponent implements OnInit {
  @Output() toggleHeaderFlagFromAuthToReg: EventEmitter<boolean> = new EventEmitter<boolean>();
  toggleToReg: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  openReg() {
    this.toggleToReg = !this.toggleToReg;
    this.toggleHeaderFlagFromAuthToReg.emit(this.toggleToReg);
  }

  // stayOnReg(e) {
  //   event.stopPropagation();
  // }

}
