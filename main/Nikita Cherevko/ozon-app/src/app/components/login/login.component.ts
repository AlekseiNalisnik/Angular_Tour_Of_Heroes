import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from 'src/app/shared/services/user.service';
import { User } from 'src/app/shared/interfaces/user';
import { ActivatedRoute } from '@angular/router';
import { EventBusService } from 'src/app/shared/services/event-bus.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  @Output() toggleHeaderFlagFromAuthToReg: EventEmitter<
    boolean
  > = new EventEmitter<boolean>();
  toggleToReg = false;
  loginForm: FormGroup;
  user: User;
  users: User[];

  formData: Object;

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private eventBusService: EventBusService
  ) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.email, Validators.required]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
      ]),
    });

    // this.userService.getUsers().subscribe(users => this.users = users);
    // console.log('users', this.users);


  }

  /* Смена флага для хэдера для открытия формы регистрации и закрытия авторизации */
  openReg() {
    this.toggleToReg = !this.toggleToReg;
    this.toggleHeaderFlagFromAuthToReg.emit(this.toggleToReg);
  }

  compareUser(user: Object) {
    this.userService
      .addUser(user as User)
      .subscribe((status) => console.log('STATUS CODE - ', status));
  }

  /* При клике на авторизационную форму входа выполняем: */
  submit() {
    if (this.loginForm.valid) {
      this.formData = { ...this.loginForm.value };
      this.compareUser(this.formData); // Post request
    }


    // this.user = this.users[1];
    // console.log('this user', this.user);

    // this.eventBusService.changeData(this.user);


    // this.userService.getUsers().subscribe((users) => {
    //   this.users = users;
    //   console.log('users', this.users);
    // });
  }
}
