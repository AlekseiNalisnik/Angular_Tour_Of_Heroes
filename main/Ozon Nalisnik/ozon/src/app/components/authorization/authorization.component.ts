import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { UserService } from '../../shared/services/user.service';
import { User } from 'src/app/shared/interfaces/user';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css']
})
export class AuthorizationComponent implements OnInit {
  @Output() toggleHeaderFlagFromAuthToReg: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() responseStatusFlag: EventEmitter<boolean> = new EventEmitter<boolean>(); // ENUM
  toggleToReg: boolean = false;

  loginForm: FormGroup;
  comparisonStatus: boolean = false;
  formData: Object;
  users: User[];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [
        Validators.email, 
        Validators.required
      ]),
      password: new FormControl('', [
        Validators.required
      ])
    });
  }

  /* Смена флага для хэдера для открытия формы регистрации и закрытия авторизации */
  openReg() {
    this.toggleToReg = !this.toggleToReg;
    this.toggleHeaderFlagFromAuthToReg.emit(this.toggleToReg);
  }

  compareUser(user: Object) {
    this.userService.addUser(user as User)
      .subscribe(status => {
        console.log('STATUS CODE - ', status);
        // this.responseStatusFlag.emit(status);
        this.responseStatusFlag.emit(true);
      })
  }

  /* При клике на авторизационную форму входа выполняем: */
  authorizationSubmit() {
    if(this.loginForm.valid) {
      this.formData = { ...this.loginForm.value }

      this.compareUser(this.formData);  // Post request
    }
  }
}
