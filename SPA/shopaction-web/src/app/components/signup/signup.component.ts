import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {AuthService} from '../../shared/services/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;
  constructor(
    public formBuilder: FormBuilder,
    public authService: AuthService,
    public router: Router
  ) {
    this.signupForm = this.formBuilder.group({
      firstName: [''],
      lastName: [''],
      dob: [''], 
      email: [''],
      phoneNumber: [''],
      userName: [''],
      password: [''],
      confirmPassword: ['']
    });
   }

  ngOnInit(): void {
  }

  registerUser(){
    this.authService.register(this.signupForm.value).subscribe((res) => {
      if (res){
        this.signupForm.reset();
        this.router.navigate(['log-in']);
      }
    })
  }

}
