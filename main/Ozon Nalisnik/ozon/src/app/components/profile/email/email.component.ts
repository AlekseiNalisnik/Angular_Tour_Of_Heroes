import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css']
})
export class EmailComponent implements OnInit {
  @Output() emailFormOutput: EventEmitter<Object> = new EventEmitter<Object>();

  emailForm: FormGroup;
  formData: Object;

  constructor() { }

  ngOnInit(): void {
    this.emailForm = new FormGroup({
      email: new FormControl('', [
        Validators.email, 
        Validators.required
      ])
    });
  }

  /* При клике на авторизационную форму входа выполняем: */
  changeEmail() {
    if(this.emailForm.valid) {
      this.formData = { ...this.emailForm.value }

      this.emailFormOutput.emit(this.formData);
      // this.compareUser(this.formData);  // Post request
    }
  }
}
