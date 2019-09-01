import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { registerAsUser } from '../../sheared/url`s/urls';
import { RegisterAsClient } from '../../sheared/user-dto/registerAsClient';

@Component({
  selector: 'app-user-register-as-client',
  templateUrl: './user-register-as-client.component.html',
  styleUrls: ['./user-register-as-client.component.scss']
})
export class UserRegisterAsClientComponent implements OnInit {
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
      confirmPassword: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(10)])
    })
  }

  onCancel() {
    console.log('cancel btn clicked');
    this.router.navigate(['']);
  }

  onSubmit() {
    if (this.userInputGroup.status !== 'INVALID'){
      if (this.userInputGroup.controls.password.value === this.userInputGroup.controls.confirmPassword.value){
        const headersContent = {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Access-Control-Allow-Headers': 'Content-Type',
        }

        const requestOptions = {                                                                                                                                                                                 
          headers: new HttpHeaders(headersContent), 
        };

        this.http.post(registerAsUser, this.userInputGroup.value, requestOptions)
        .subscribe(
          (next) => console.log(next),
          (error) => console.log(error),
          () => this.router.navigate(['login']));
      }
    }
  }
}
