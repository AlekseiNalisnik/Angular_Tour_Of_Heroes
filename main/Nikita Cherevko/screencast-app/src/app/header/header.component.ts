import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  public isShown = true;

  public myclass = 'red';
  public mycolor = 'red';


  public users;
  public selectedUser;

  constructor(
    private userService: UserService,
    private http: HttpClient) {
   }

  ngOnInit(): void {
    this.userService.getAll().subscribe(users => this.users = users);
  }

  changeColor(color) {
    this.mycolor = color;
  }
}
