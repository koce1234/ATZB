
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RootUserModule } from './user-pages/RootUserModule';
import { NavigationModule } from './naviagation-paterns/NavigationModule';
import { HomePageComponent } from './sheared/home-page/home-page.component';
import { PageNotFoundComponent } from './sheared/page-not-found/page-not-found.component';
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
    RootUserModule,
    NavigationModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
