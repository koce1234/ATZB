import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import bootstrap from "bootstrap";
import { HomeComponent } from './Home/home.component';
import { UserRegisterComponent } from './UserPages/user-register/user-register.component';
import { UserLogInComponent } from './UserPages/user-log-in/user-log-in.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UserRegisterComponent,
    UserLogInComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
