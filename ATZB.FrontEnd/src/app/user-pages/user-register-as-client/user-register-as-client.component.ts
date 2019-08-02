import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-register-as-client',
  templateUrl: './user-register-as-client.component.html',
  styleUrls: ['./user-register-as-client.component.css']
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
    console.log('register btn clicked');
    console.log(this.userInputGroup);

    debugger;
    
    if (this.userInputGroup.status !== 'INVALID'){
      if (this.userInputGroup.controls.password.value === this.userInputGroup.controls.confirmPassword.value){
        let sentData = [
          this.userInputGroup.controls.firstName.value,
          this.userInputGroup.controls.lastName.value,
          this.userInputGroup.controls.email.value,
          this.userInputGroup.controls.streetAddress.value,
          this.userInputGroup.controls.phone.value,
          this.userInputGroup.controls.city.value,
          this.userInputGroup.controls.password.value,
        ];
        
        this.http.post('https://localhost:44379/api/user/register', sentData)
      }
    }
  }
}
