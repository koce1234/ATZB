import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import * as httpUrls from '../../sheard/url`s/urls';
import { FormGroup, FormControl } from '@angular/forms';
import { Order } from 'src/app/sheard/models/order.interface';
import { Router } from '@angular/router';
import { Cities } from 'src/app/sheard/location/cities.enum';

@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.css']
})
export class UserOrdersComponent implements OnInit {
  allOrders: Order[] = [];
  myOrders: Order[] = [];
  keys = Object.values;
  dataSourse: any;
  cities = Cities;
  showAllOrdersForm: boolean;
  showAddOrderForm: boolean;
  showMyOrdersForm: boolean;
  addOrderFormGroup: FormGroup;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.showAllOrdersForm = true;
    this.showAddOrderForm = false;
    this.showMyOrdersForm = false;
    console.log(this.cities);

    let headers = new HttpHeaders;
    headers = headers.set("Authorization", "Bearer " + localStorage.getItem('token'));

    // this.http.get(httpUrls.getAllOrders, {headers: headers}).subscribe(
    //   (next: Order[]) => {
    //     console.log(next);
    //     this.allOrders = next
    //   },
    //   (error) => console.log(error),
    //   () => console.log('compleeted')
    // );
  }

  addOrder() {
    this.showAllOrdersForm = false;
    this.showAddOrderForm = true;
    this.showMyOrdersForm = false;
    this.addOrderFormGroup = new FormGroup({
      description: new FormControl(''),
      priceTo: new FormControl(''),
      city: new FormControl('')
    })
  }

  submitOrder() {
    console.log(this.addOrderFormGroup.value);
    console.log(this.cities);

    let headers = new HttpHeaders;
    headers = headers.set("Authorization", "Bearer " + localStorage.getItem('token'));
    headers = headers.set("UserId", localStorage.getItem('userId'));

    this.http.post(httpUrls.addOrder, this.addOrderFormGroup.value, { headers: headers })
      .subscribe(
        (next) => console.log(next),
        (error) => console.log(error),
        () => this.showAllOrders()
    );
  }

  showMyOrders() {
    this.showAllOrdersForm = false;
    this.showAddOrderForm = false;
    this.showMyOrdersForm = true;
    let headers = new HttpHeaders;
    headers = headers.set("Authorization", "Bearer " + localStorage.getItem('token'));
    headers = headers.set('userId', localStorage.getItem('userId'));

    this.http.get(httpUrls.seeAllMyOrders, { headers })
      .subscribe(
        (next: Order[]) => this.myOrders = next,
        (error) => console.log(error),
        () => console.log('compleeted')
      )
  }

  showAllOrders() {
    this.showAllOrdersForm = true;
    this.showAddOrderForm = false;
    this.showMyOrdersForm = false;

    let headers = new HttpHeaders;
    headers = headers.set("Authorization", "Bearer " + localStorage.getItem('token'));

    // this.http.get(httpUrls.getAllOrders, {headers: headers}).subscribe(
    //   (next: Order[]) => {
    //     this.allOrders = next;
    //     this.dataSourse = this.allOrders;
    //   },
    //   (error) => console.log(error),
    //   () => console.log('compleeted')
    // );
  }
}
