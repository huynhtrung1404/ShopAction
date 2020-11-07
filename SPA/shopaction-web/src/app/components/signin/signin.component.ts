import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {AuthService} from '../../shared/services/auth.service';
import {Router} from '@angular/router';
import {InputModel} from '../../models/InputModel';
import { LoginUser } from '../../models/LoginUser';
import { IconAlias } from '../constant/icon-alias';
 
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  signinForm: FormGroup;
  userLogin: LoginUser = new LoginUser();
  iconAlias: IconAlias = new IconAlias();
  loginError =  {
    userName: "",
    password: ""
  };
  constructor(    
    public formBuilder: FormBuilder,
    public authService: AuthService,
    public router: Router
  ) { 
    this.signinForm = this.formBuilder.group({
      userName: [''],
      password:['']
    })
  }

  ngOnInit(): void {
  }

  loginUser() {
    //console.log(this.userLogin);
    let isFormValid = this.loginFormValidation();
    if(isFormValid) this.authService.login(this.userLogin);
  }

  getInput(icon:string, type:string, value: string, placeholder: string, name: string): InputModel {
    let result: InputModel = {
      icon : icon,
      inputType : type,
      placeHolder : placeholder,
      value : value,
      name: name
    };
    return result;
  }

  getUserNameValue(event){
    if(!!event.target.value){
      this.loginError.userName = '';
      this.userLogin.userName = event.target.value;
    }
    else {
      this.loginError.userName = 'Username is required!'; 
    }
  }

  getPasswordValue(event){
    if(!!event.target.value){
      this.loginError.password = ''; 
      this.userLogin.password = event.target.value;
    }
    else {
      this.loginError.password = 'Password is required!'; 
    }
  }

  loginFormValidation(){
    let valid = false;
    if(!this.userLogin.userName){
      this.loginError.userName = 'Username is required!';
    }
    if(!this.userLogin.password){
      this.loginError.password = 'Password is required!';
    }
    if(this.userLogin.userName && this.userLogin.password){
      valid = true;
    }
    return valid;
  }

}
