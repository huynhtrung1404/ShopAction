import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {AuthService} from '../../shared/services/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  signinForm: FormGroup;
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
    this.authService.login(this.signinForm.value);
  }

}
