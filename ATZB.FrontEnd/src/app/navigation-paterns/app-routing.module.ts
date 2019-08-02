import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserLoginComponent } from '../user-pages/user-login/user-login.component';
import { UserRegisterAsClientComponent } from '../user-pages/user-register-as-client/user-register-as-client.component';
import { UserRegisterAsPerformerComponent } from '../user-pages/user-register-as-performer/user-register-as-performer.component';
import { HomePageComponent } from '../sheard/home-page/home-page.component';
import { PageNotFoundComponent } from '../sheard/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', component: HomePageComponent, pathMatch: 'full' },
  { path: 'registerAsClient', component: UserRegisterAsClientComponent },
  { path: 'registeAsPerformer', component: UserRegisterAsPerformerComponent },
  { path: 'login', component: UserLoginComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
