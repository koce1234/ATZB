import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as httpUrls from '../../sheard/url`s/urls';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
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
      this.http.post(httpUrls.userLogin, this.logInInput.value, requestOptions)
        .subscribe(
          (next: { token: string, userId: string }) => {
            localStorage.setItem('token', next.token);
            localStorage.setItem('userId', next.userId);
            this.router.navigate(['']);
          },
          (error) => console.log(error),
          () => console.log('kur')
      );
    }
  }
}
