import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {AuthService} from '../../shared/services/auth.service';
import {Router} from '@angular/router';
import {InputModel} from '../../models/InputModel';
import {IconAlias} from '../constant/icon-alias';
import { RegisterUser } from 'src/app/shared/RegisterUser';
import PasswordCheck from 'src/app/shared/utils/PasswordValidation';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;
  iconAlias: IconAlias = new IconAlias();
  _registerUser: RegisterUser = new RegisterUser();
  passwordValidation: PasswordCheck = new PasswordCheck();
  registerError = {
    firstName: "",
    lastName: "",
    dob: "",
    email: "",
    phoneNumber: "",
    userName: "",
    password: "",
    confirmPassword: ""
  };
  
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
    let isFormValid = this.registerValidation();
    if(isFormValid){
      this.authService.register(this.signupForm.value).subscribe((res) => {
        if (res){
          this.signupForm.reset();
          this.router.navigate(['log-in']);
        }
      })
    }
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

  getFirstName(event){
    debugger;
    if(!!event.target.value){
      this.registerError.firstName = "";
      this._registerUser.firstName = event.target.value;
    }else {
      this.registerError.userName = 'Firstname is required!'; 
    }
  };

  getLastName(event){
    if(!!event.target.value){
      this.registerError.lastName = "";
      this._registerUser.lastName = event.target.value; 
    }else {
      this.registerError.lastName = 'Lastname is required!'; 
    }
  };

  getDoB(event){
    if(!!event.target.value){
      this.registerError.dob = "";
      this._registerUser.dob = event.target.value; 
    }else {
      this.registerError.dob = 'Date of birth is required!'; 
    }
  };

  getEmail(event){
    if(!event.target.value){ 
      this.registerError.email = 'Email is required!'; 
    }
    else if(!!event.target.value && !this.isValidEmail(event.target.value)){
      this.registerError.email = "Invalid Email";
    }
    else {
      this.registerError.email = "";
      this._registerUser.email = event.target.value;
    }
  };

  getPhoneNumber(event){
    if(!event.target.value){ 
      this.registerError.phoneNumber = 'Phone number is required!'; 
    }else {
      this.registerError.phoneNumber = "";
      this._registerUser.phoneNumber = event.target.value;
    }
  };

  getUserName(event){
    if(!event.target.value){ 
      this.registerError.userName = 'Username is required!'; 
    }else {
      this.registerError.userName = "";
      this._registerUser.userName = event.target.value;
    }
  };

  getPassword(event){
    if(!event.target.value){ 
      this.registerError.password = 'Password is required!'; 
    }
    else if(!!event.target.value && !this.passwordValidation.isValidPassword(event.target.value, 8, false, true, true, true)){
      this.registerError.password = 'Invalid password'; 
    }
    else {
      this.registerError.password = "";
      this._registerUser.password = event.target.value;
    }
  };

  getConfirmPassword(event){
    if(!event.target.value){ 
      this.registerError.confirmPassword = 'Confirm password is required!'; 
    }
    else if(!!event.target.value && !this._registerUser.password){
      this.registerError.confirmPassword = 'Enter password first!'; 
    }
    else if(!!event.target.value && !!this._registerUser.password && this._registerUser.password !== event.target.value){
      this.registerError.confirmPassword = 'Password not match'; 
    }
    else {
      this.registerError.confirmPassword = "";
      this._registerUser.confirmPassword = event.target.value;
    }
  };

  isValidEmail(email: String) {
    let valid = false;
    let regexp = new RegExp("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$");
    valid = regexp.test(email.toString());
    return valid;
  }

  registerValidation(){
    let valid = false;
    if(!this._registerUser.userName){
      this.registerError.userName = 'Username is required!';
    }
    if(!this._registerUser.password){
      this.registerError.password = 'Password is required!';
    }
    if(this._registerUser.userName && this._registerUser.password){
      valid = true;
    }
    return valid;
  }
}
