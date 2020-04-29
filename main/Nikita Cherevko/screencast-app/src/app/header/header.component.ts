import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  public isShown = true;

  public myclass = 'red';
  public mycolor = 'red';
  public user = {
    name : 'Nik'
  };
  public users = [
    {name: 'John'},
    {name: 'Nik'},
    {name: 'Lex'},
    {name: 'Sux'},
    {name: 'Ang'}
  ];
  public selectedUser;

  constructor() {
   }

  ngOnInit(): void {
  }

  changeColor(color) {
    this.mycolor = color;
  }
}
