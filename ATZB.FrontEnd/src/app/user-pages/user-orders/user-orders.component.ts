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
  allOrders: {description: string, priceTo: number, town: string}[] = [];
  myOrders: any[] = [];
  dataSourse: any;
  showAllOrdersForm: boolean;
  showAddOrderForm: boolean;
  showMyOrdersForm: boolean;
  addOrderFormGroup: FormGroup;
  displayedColumns: string[] = ['description', 'town', 'priceTo']

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.showAllOrdersForm = true;
    this.showAddOrderForm = false;
    this.showMyOrdersForm = false;

    let headers = new HttpHeaders;
    headers = headers.set("Authorization", "Bearer " + localStorage.getItem('token'));

    this.http.get(httpUrls.getAllOrders, {headers: headers}).subscribe(
      (next: {description: string, priceTo: number, town: string}[]) => {
        console.log(next);
        this.allOrders = next
      },
      (error) => console.log(error),
      () => console.log('compleeted')
    );
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
    let headers = new HttpHeaders;
    headers = headers.set("Authorization", "Bearer " + localStorage.getItem('token'));

    this.http.post(httpUrls.addOrder, this.addOrderFormGroup.value, { headers: headers })
      .subscribe(
        (next) => console.log(next),
        (error) => console.log(error),
        () => console.log('complete')
      );

      this.showAllOrdersForm = true;
    this.showAddOrderForm = false;
    this.showMyOrdersForm = false;
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

  showAllOrders() {
    this.showAllOrdersForm = true;
    this.showAddOrderForm = false;
    this.showMyOrdersForm = false;

    let headers = new HttpHeaders;
    headers = headers.set("Authorization", "Bearer " + localStorage.getItem('token'));

    this.http.get(httpUrls.getAllOrders, {headers: headers}).subscribe(
      (next: {description: string, priceTo: number, town: string}[]) => {
        this.allOrders = next;
        this.dataSourse = this.allOrders;
      },
      (error) => console.log(error),
      () => console.log('compleeted')
    );
  }
}
