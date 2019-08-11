import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import * as httpUrls from '../../sheard/url`s/urls';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.css']
})
export class UserOrdersComponent implements OnInit {
  allOrders: any[] = [];
  myOrders: any[] = [];
  showAllOrdersForm: boolean;
  showAddOrderForm: boolean;
  showMyOrdersForm: boolean;
  addOrderFormGroup: FormGroup;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.showAllOrdersForm = true;
    this.showAddOrderForm = false;
    this.showMyOrdersForm = false;

    let headers = new HttpHeaders;
    headers = headers.set("Authorization", "Bearer " + localStorage.getItem('token'));

    this.http.get(httpUrls.getAllOrders, {headers: headers}).subscribe(
      (next) => console.log(next),
      (error) => console.log(error),
      () => console.log('compleeted')
    )
  }

  addOrder() {
    this.showAllOrdersForm = false;
    this.showAddOrderForm = true;
    this.showMyOrdersForm = false;
    this.addOrderFormGroup = new FormGroup({
      description: new FormControl(''),
      priceTo: new FormControl(''),
      town: new FormControl('')
    })
  }

  submitOrder() {
    console.log('submit button clicked');
    console.log(this.addOrderFormGroup);
  }

  showMyOrders() {
    this.showAllOrdersForm = false;
    this.showAddOrderForm = false;
    this.showMyOrdersForm = true;
    let headers = new HttpHeaders;
    headers = headers.set("Authorization", "Bearer " + localStorage.getItem('token'));
    headers = headers.set('userId', localStorage.getItem('userId'));

    this.http.get(httpUrls.getMyOrders, { headers })
      .subscribe(
        (next) => console.log(next),
        (error) => console.log(error),
        () => console.log('compleeted')
      )
  }
}
