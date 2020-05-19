import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import {User} from '../interfaces/user';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private usersUrl = 'api/users';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.usersUrl).pipe(
      catchError(this.handleError<User[]>())
    );
  }

  addUser(user: User): Observable<User> {
    return this.http.post<User>(this.usersUrl, user, this.httpOptions)
      .pipe(
        catchError(this.handleError<User>())
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    };
  }

  changeUserData(user: User):Observable<User> {
    return this.http.put<User>(this.usersUrl, user);
  }

  getUserById(id: string) {
    return this.http.get(this.usersUrl, {
      params: new HttpParams().set('id', id),
    });
  }

}
