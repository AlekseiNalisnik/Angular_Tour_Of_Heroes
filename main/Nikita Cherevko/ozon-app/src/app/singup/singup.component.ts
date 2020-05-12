import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { User } from '../interfaces/user';
import { AuthService } from '../services/auth.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-singup',
  templateUrl: './singup.component.html',
  styleUrls: ['./singup.component.css']
})
export class SingupComponent implements OnInit {
  @Output() toggleHeaderFlag: EventEmitter<boolean> = new EventEmitter<boolean>();
  toggleToAuth = false;

  singUpForm: FormGroup;

  public id = 0;

  constructor(
    private auth: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.singUpForm = new FormGroup({
      fullName: new FormControl('', [
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

  opeanAuth() {
    this.toggleToAuth = !this.toggleToAuth;
    this.toggleHeaderFlag.emit(this.toggleToAuth);
  }

  stayOnAuth(e) {
    // tslint:disable-next-line: deprecation
    event.stopPropagation();
  }

  submit() {
    console.log(this.singUpForm.value);
    this.opeanAuth();

    this.id += 1;
    const user: User = {
      mail: this.singUpForm.value.email,
      password: this.singUpForm.value.password,
      id: this.id,
      surname: this.singUpForm.value.fullName,
      name: this.singUpForm.value.fullName,
      patronymic: this.singUpForm.value.fullName,
      phoneNumber: this.singUpForm.value.phoneNumber,
      sex: '',
      birth: ''
   };

    // this.auth.login(user).subscribe(() => {
    //   this.singUpForm.reset();
    //   this.router.navigate(['../profile']);
    // });
  }

}
