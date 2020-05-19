import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/services/user.service';
import { User } from '../../shared/interfaces/user';
import { MaindbService } from '../../shared/services/maindb.service';
import { ActivatedRoute, Params } from '@angular/router';
import { EventBusService } from 'src/app/shared/services/event-bus.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  users: User[];
  user: User;
  changePhoneForm: FormGroup;

  phoneChangeFlag = true;

  constructor(
    private userService: UserService,
    private route: ActivatedRoute
  ) // private eventBusService: EventBusService
  {}

  ngOnInit(): void {
    this.changePhoneForm = new FormGroup({
      phone: new FormControl(null, [
        Validators.required,
        Validators.minLength(8),
        Validators.pattern(/^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/),
      ]),
    });
  }

  changePhone() {
    this.phoneChangeFlag = false;
    console.log(this.phoneChangeFlag);

    // this.changePhoneForm = new FormGroup({
    //   phone: new FormControl(null, [
    //     Validators.required,
    //     Validators.minLength(8),
    //     Validators.pattern(/^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/),
    //   ]),
    // });
  }

  changeEmail() {}

  changePersonalData() {}

  deleteProfile() {}

  phoneChangesubmit() {
    console.log(this.changePhoneForm);
    this.phoneChangeFlag = true;
    console.log('flag - ', this.phoneChangeFlag);

    if (this.changePhoneForm.valid) {
      this.userService
        .changeUserData(this.user)
        .subscribe((resolve) => console.log(resolve));
      this.phoneChangeFlag = true;
      console.log('flag - ', this.phoneChangeFlag);
    }
  }
}
