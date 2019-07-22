import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Home/home.component';
import { UserRegisterComponent } from './UserPages/user-register/user-register.component';
import { UserLogInComponent } from './UserPages/user-log-in/user-log-in.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'register', component: UserRegisterComponent },
  { path: 'login', component: UserLogInComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
