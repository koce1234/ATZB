import { NgModule } from '@angular/core';

import { NavigationNotLogedIn } from './navigation-not-loged-in/navigation-not-loged-in';
import { NavigationLogedInComponent } from './navigation-loged-in/navigation-loged-in.component';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../MaterialModule';
import { Routes, RouterModule } from '@angular/router';
import { UserLoginComponent } from '../user-pages/user-login/user-login.component';
import { UserRegisterAsClientComponent } from '../user-pages/user-register-as-client/user-register-as-client.component';
import { HomePageComponent } from '../sheared/home-page/home-page.component';
import { PageNotFoundComponent } from '../sheared/page-not-found/page-not-found.component';


const routes: Routes = [
  { path: '', component: HomePageComponent, pathMatch: 'full' },
  { path: 'registerAsClient', component: UserRegisterAsClientComponent },
  { path: 'login', 
    component: UserLoginComponent, 
    loadChildren: () => import('../user-pages/RootUserModule').then(x => x.RootUserModule) 
  },
  { path: '**', component: PageNotFoundComponent }
];


@NgModule({
    declarations: [
        NavigationLogedInComponent,
        NavigationNotLogedIn,
    ],
    imports: [
        CommonModule,
        MaterialModule,
        RouterModule.forRoot(routes),
    ],
    exports: [
        CommonModule,
        NavigationLogedInComponent,
        NavigationNotLogedIn,
        MaterialModule,
        RouterModule,
        RouterModule,
    ]
})
export class NavigationModule{}


