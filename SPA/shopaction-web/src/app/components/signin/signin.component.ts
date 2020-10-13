import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {AuthService} from '../../shared/services/auth.service';
import {Router} from '@angular/router';
import {InputControlComponent} from '../common/input-control/input-control.component';
import {InputModel} from '../../models/InputModel';
import { LoginUser } from 'src/app/shared/LoginUser';
import { IconAlias } from '../constant/icon-alias';
 
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  signinForm: FormGroup;
  _loginUser: LoginUser = new LoginUser();
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
    console.log(this._loginUser)
    this.authService.login(this._loginUser);
  }

  getInput(icon:string, type:string, value: string, placeholder: string, name: string): InputModel {
    var result: InputModel = {
      icon : icon,
      inputType : type,
      placeHolder : placeholder,
      value : value,
      name: name
    };
    return result;
  }

  getValue(event){
    var _name = event.target.name;
    var _value = event.target.value;
    if(!_name && _name == "userName") this._loginUser.userName = _value;
    if(!_name && _name =="password") this._loginUser.password =  _value;
    debugger;
    console.log(this._loginUser);
  }

}
