import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { UserService } from '../../shared/services/user.service';
import { User } from '../../shared/interfaces/User';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css']
})
export class AuthorizationComponent implements OnInit {
  @Output() toggleHeaderFlagFromAuthToReg: EventEmitter<boolean> = new EventEmitter<boolean>();
  toggleToReg: boolean = false;

  authorizationForm: FormGroup;
  comparisonStatus: boolean = false;
  formData: Object;
  users: User[];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.authorizationForm = new FormGroup({
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
      .subscribe(status => console.log('STATUS CODE - ', status))
  }

  /* При клике на авторизационную форму входа выполняем: */
  authorizationSubmit() {
    if(this.authorizationForm.valid) {
      this.formData = { ...this.authorizationForm.value }

      this.compareUser(this.formData);  // Post request
    }
  }
}
