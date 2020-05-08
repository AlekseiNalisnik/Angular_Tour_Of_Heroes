import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { User } from '../interfaces/user';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private usersUrl = 'api/users';

  constructor(private http: HttpClient) { }

  get token(): string {
    return '';
  }

  private setToken(response) {
    console.log(response);
  }

  login(user: User): Observable<any> {
    return this.http.post('userUrl', user).pipe(
      tap(this.setToken)
    );
  }

  logout() {

  }

  isAuthenticated(): boolean {
    return !!this.token;
  }
}
