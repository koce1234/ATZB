import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as httpUrls from '../../sheard/url`s/urls';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
  logInInput: FormGroup;

  constructor(private http: HttpClient) { }

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
          (next: KeyValue<string, string>) => localStorage.setItem('token', next.value),
          (error) => console.log(error),
          () => console.log('kur')
      );
    }
  }
}
