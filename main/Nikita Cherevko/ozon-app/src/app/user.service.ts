import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import {User} from './user';
import {Users} from './mock-users';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  getUsers(): Observable<User[]> {
    return of(Users);
  }
}
