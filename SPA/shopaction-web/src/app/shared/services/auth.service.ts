import { Injectable } from '@angular/core';
import {RegisterUser} from '../RegisterUser';
import {LoginUser} from '../LoginUser';
import {Observable, throwError} from 'rxjs';
import {catchError, map} from 'rxjs/operators';
import {HttpClient, HttpHeaders, HttpErrorResponse} from '@angular/common/http';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  endpoint : string = 'http://192.168.1.163:5001/api/user';
  header = new HttpHeaders().set('Content-Type','application/json');
  currentUser = {};
  constructor(
    private http: HttpClient,
    public router: Router
  ) { }

  register(user: RegisterUser):Observable<any>{
    let api = `${this.endpoint}/register`;
    return this.http.post(api,user)
    .pipe(catchError(this.handleError))
  }

  login(user:LoginUser){
    return this.http.post<any>(`${this.endpoint}/login`,user)
      .subscribe((res:any) => {
        localStorage.setItem('access_token', res.token)
      })
  }

  getToken(){
    return localStorage.getItem('access_token');
  }

  get isLoggedIn():boolean {
    let authToken = localStorage.getItem('access_token');
    return authToken !== null ? true : false;
  }

  doLogout() {
    let removeToken = localStorage.removeItem('access_token');
    if (removeToken == null) {
      this.router.navigate(['log-in']);
    }
  }

  //Error
  handleError(error: HttpErrorResponse){
    let mgs = '';
    if (error.error instanceof ErrorEvent) {
      mgs = error.error.message;
    }
    else {
      mgs = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(mgs);
  }
}
