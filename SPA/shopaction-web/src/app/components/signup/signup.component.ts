import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {AuthService} from '../../shared/services/auth.service';
import {Router} from '@angular/router';
import {InputModel} from '../../models/InputModel';
import {IconAlias} from '../constant/icon-alias';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;
  iconAlias: IconAlias = new IconAlias();
  
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

  getRegisterUserModel(icon:string, type:string, value: string, placeholder: string, name: string): InputModel {
    var result: InputModel = {
      icon : icon,
      inputType : type,
      placeHolder : placeholder,
      value : value,
      name: name
    };
    return result;
  }
}
