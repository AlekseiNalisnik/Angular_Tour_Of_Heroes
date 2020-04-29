import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {

  @Input() user;
  @Output("userSelected") userSelected: EventEmitter<any> = new EventEmitter();

  constructor() {
    console.log('constructor: ', this.user);
   }

  ngOnInit(): void {
    console.log('ngOnInit: ', this.user);
  }

  selectUser() {
    this.userSelected.emit();
  }
}
