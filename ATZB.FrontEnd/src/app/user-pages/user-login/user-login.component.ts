import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {userLogin} from '../../sheared/url`s/urls';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { LogedUser } from '../../sheared/models/loged-user.interface';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent implements OnInit {
  logInInput: FormGroup;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.logInInput = new FormGroup({
      email: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    })
  }

  onLogin() {
    const headersContent = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
    }

    const requestOptions = {                                                                                                                                                                                 
      headers: new HttpHeaders(headersContent), 
    };

    if(this.logInInput.valid){
      this.http.post(userLogin, this.logInInput.value, requestOptions)
        .subscribe(
          (next: LogedUser) => {
            localStorage.setItem('token', next.token);
            localStorage.setItem('userId', next.userId);
            localStorage.setItem('fullName', next.fullName);
            this.router.navigate(['']);
          },
          (error) => console.log(error),
          () => console.log('kur')
      );
    }
  }
}
