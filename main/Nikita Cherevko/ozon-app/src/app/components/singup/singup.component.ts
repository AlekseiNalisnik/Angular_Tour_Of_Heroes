import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { User } from '../../shared/interfaces/user';
import { AuthService } from '../../shared/services/auth.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';


@Component({
  selector: 'app-singup',
  templateUrl: './singup.component.html',
  styleUrls: ['./singup.component.css']
})
export class SingupComponent implements OnInit {
  @Output() toggleHeaderFlag: EventEmitter<boolean> = new EventEmitter<boolean>();
  toggleToAuth = false;
  formData: Object;
  singUpForm: FormGroup;

  public id = 0;

  constructor(
    private auth: AuthService,
    private router: Router,
    private userService: UserService) { }

  ngOnInit(): void {
    this.singUpForm = new FormGroup({
      name: new FormControl('', [
        Validators.required
       ]),
      surname: new FormControl('', [
        Validators.required
       ]),
      patronimyc: new FormControl('', [
         Validators.required
        ]),
      phoneNumber: new FormControl(null, [
        Validators.required,
        Validators.minLength(8),
        Validators.pattern(/^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/)
      ]),
      email: new FormControl('', [
        Validators.email,
        Validators.required,
      ]),
      password: new FormControl(null, [
        Validators.required,
        Validators.minLength(6)
      ])
    });
  }

  openAuth() {
    this.toggleToAuth = !this.toggleToAuth;
    this.toggleHeaderFlag.emit(this.toggleToAuth);
    console.log('flag - ', this.toggleToAuth);
  }

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
  submit() {
    if(this.singUpForm.valid) {
      this.formData = { ...this.singUpForm.value };

      this.openAuth();      // Сразу после отправки на форму, переходим к открытию авторизации

      this.addUser(this.formData);
    }
  }

}
