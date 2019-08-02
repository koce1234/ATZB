import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { MainNavNotLogedInComponent } from './main-nav-not-loged-in/main-nav-not-loged-in.component';
import { MainNavComponent } from './main-nav-loged-in/main-nav.component';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../MaterialModule';

@NgModule({
    declarations: [
        MainNavComponent,
        MainNavNotLogedInComponent,
    ],
    imports: [
        AppRoutingModule,
        CommonModule,
        MaterialModule,
    ],
    exports: [
        AppRoutingModule,
        CommonModule,
        MainNavComponent,
        MainNavNotLogedInComponent,
        MaterialModule,
    ]
})
export class NavigationModule{}