import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import * as httpUrls from '../../sheard/url`s/urls';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-register-as-performer',
  templateUrl: './user-register-as-performer.component.html',
  styleUrls: ['./user-register-as-performer.component.css']
})
export class UserRegisterAsPerformerComponent implements OnInit {
  userInputGroup: FormGroup;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.userInputGroup = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.minLength(3)]),
      lastName: new FormControl('', [Validators.required, Validators.minLength(4)]),
      email: new FormControl('', [Validators.required, 
        Validators.pattern("^(([^<>()\\[\\]\\\\.,;:\\s@\"]+(\\.[^<>()\\[\\]\\\\.,;:\\s@\\\"]+)*)|(\".+\"))@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$")]),
      streetAddress: new FormControl('', []),
      phone: new FormControl('', [Validators.required, Validators.pattern("^[0-9\\-\\+]{9,15}$")]),
      city: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(10)]),
      confirmPassword: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(10)]),
      egn: new FormControl(''),
      LKNumber: new FormControl(''),
      enk: new FormControl(''),
      ddsNumber: new FormControl(''),
      hasObligations: new FormControl('')
    })
  }

  onCancel() {
    console.log('Cancel btn clicked');
    this.router.navigate(['']);
  }

  onSubmit() {
    console.log(this.userInputGroup.value);
    if (this.userInputGroup.status !== 'INVALID'){
      if (this.userInputGroup.controls.password.value === this.userInputGroup.controls.confirmPassword.value){
        const headers = {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Access-Control-Allow-Headers': 'Content-Type',
        }

        const requestOptions = {                                                                                                                                                                                 
          headers: new HttpHeaders(headers), 
        };

        this.http.post(httpUrls.registerAsPerformer, this.userInputGroup.value, requestOptions)
        .subscribe(
          (next) => console.log(next),
          (error) => console.log(error),
          () => this.router.navigate(['login']));
      }
    }
  }
}
