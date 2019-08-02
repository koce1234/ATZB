
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { UserModule } from './user-pages/UserModule';
import { NavigationModule } from './navigation-paterns/NavigationModule';
import { HomePageComponent } from './sheard/home-page/home-page.component';
import { PageNotFoundComponent } from './sheard/page-not-found/page-not-found.component';
import { MaterialModule } from './MaterialModule';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    UserModule,
    NavigationModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
