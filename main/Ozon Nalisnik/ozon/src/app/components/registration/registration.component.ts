import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { UserService } from '../../shared/services/user.service';
import { User } from 'src/app/shared/interfaces/user';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  @Output() toggleHeaderFlag: EventEmitter<boolean> = new EventEmitter<boolean>();
  toggleToAuth: boolean = false;

  registrationForm: FormGroup;
  formData: Object;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.registrationForm = new FormGroup({
      email: new FormControl('', [
        Validators.email, 
        Validators.required
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(8)
      ]),
      name: new FormControl('', [
        Validators.required
      ]),
      phone: new FormControl('', [
        Validators.required,
        Validators.pattern(/^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/)
      ])
    });
  }

  /* Смена флага для хэдера для открытия формы авторизации */
  openAuth() {
    this.toggleToAuth = !this.toggleToAuth;
    this.toggleHeaderFlag.emit(this.toggleToAuth);
  }

  /* Прерываем всплытие для того, чтобы мы могли кликать ВНУТРИ формы */
  stayOnAuth(e) {
    event.stopPropagation();
  }

  /* Добавление пользователя в БД */
  addUser(userData: Object): void {
    if(Object.keys(userData).length === 0) return;  // Проверка на пустоту объекта
    
    this.userService.addUser(userData as User)
      .subscribe(userData => console.log('User - ', userData))
  }

  /* При клике на регистрационную форму отправки данных выполняем: */
  registrationSubmit() {
    if(this.registrationForm.valid) {
      this.formData = { ...this.registrationForm.value };

      this.openAuth();      // Сразу после отправки на форму, переходим к открытию авторизации

      this.addUser(this.formData);
    }
  }
}
