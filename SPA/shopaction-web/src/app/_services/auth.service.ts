import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';

const AUTH_API = 'https://localhost:5001/api/users/';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type':'application/json'})
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }

  register(user):Observable<any>{
    return this.http.post(AUTH_API + 'register', {
      firstName: user.firstName,
      lastName: user.lastName,
      dob: new Date(),
      email: user.email,
      phoneNumber: user.phoneNumber,
      userName: user.userName,
      password: user.password,
      confirmPassword: user.confirmPassword
    }, httpOptions);
  }
}
