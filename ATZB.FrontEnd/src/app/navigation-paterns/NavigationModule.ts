import { NgModule } from '@angular/core';

import { MainNavNotLogedInComponent } from './main-nav-not-loged-in/main-nav-not-loged-in.component';
import { MainNavComponent } from './main-nav-loged-in/main-nav.component';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../MaterialModule';
import { Routes, RouterModule } from '@angular/router';
import { UserLoginComponent } from '../user-pages/user-login/user-login.component';
import { UserRegisterAsClientComponent } from '../user-pages/user-register-as-client/user-register-as-client.component';
import { UserRegisterAsPerformerComponent } from '../user-pages/user-register-as-performer/user-register-as-performer.component';
import { HomePageComponent } from '../sheard/home-page/home-page.component';
import { PageNotFoundComponent } from '../sheard/page-not-found/page-not-found.component';
import { UserOrdersComponent } from '../user-pages/user-orders/user-orders.component';
import { UserOffersToMeComponent } from '../user-pages/user-offers-to-me/user-offers-to-me.component';
import { UserComponent } from '../user-pages/user/user.component';

const routes: Routes = [
  { path: '', component: HomePageComponent, pathMatch: 'full' },
  { path: 'registerAsClient', component: UserRegisterAsClientComponent },
  { path: 'registeAsPerformer', component: UserRegisterAsPerformerComponent },
  { path: 'login', component: UserLoginComponent },
  { path: 'orders', component: UserOrdersComponent },
  { path: 'offersToMe', component: UserOffersToMeComponent  },
  { path: 'profile', component: UserComponent },
  { path: '**', component: PageNotFoundComponent }
];


@NgModule({
    declarations: [
        MainNavComponent,
        MainNavNotLogedInComponent,
    ],
    imports: [
        CommonModule,
        MaterialModule,
        RouterModule.forRoot(routes),
    ],
    exports: [
        CommonModule,
        MainNavComponent,
        MainNavNotLogedInComponent,
        MaterialModule,
        RouterModule,
    ]
})
export class NavigationModule{}