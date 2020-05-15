import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../interfaces/user';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  users: User[];
  user: User;
  constructor(
    private userService: UserService,
    // private mainDb: MaindbService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      console.log(params);
//      this.user = this.mainDb.getUserById(+params.id);
    });
  }

  getUsers(): void {
    this.userService.getUsers().subscribe((users) => (this.users = users));
  }
}
