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
  userLogin: LoginUser;
  iconAlias: IconAlias = new IconAlias();
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
    //console.log(this.userLogin)
    this.authService.login(this.userLogin);
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

  getValue(event){
    console.log(this.userLogin);
    let _name = event.target.name;
    let _value = event.target.value;
    if(!_name && _name == "userName") this.userLogin.userName =  _value;
    if(!_name && _name =="password") this.userLogin.password =  _value;
    //debugger;
    console.log(this.userLogin);
  }

}
