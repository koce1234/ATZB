import { NgModule } from '@angular/core';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserRegisterAsClientComponent } from './user-register-as-client/user-register-as-client.component';
import { MaterialModule } from '../MaterialModule';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatRadioModule } from '@angular/material/radio';
import { UserOrdersComponent } from './user-orders/user-orders.component';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatExpansionModule } from '@angular/material/expansion';
import { UserOffersToMeComponent } from './user-offers-to-me/user-offers-to-me.component';
import { UserComponent } from './user/user.component';
import { RouterModule } from '@angular/router';
import { MatSelectModule } from '@angular/material';

const routs = [
    { path: 'orders', component: UserOrdersComponent },
    { path: 'offersToMe', component: UserOffersToMeComponent },
    { path: 'profile', component: UserComponent },
];

@NgModule({
    declarations:[
        UserLoginComponent,
        UserRegisterAsClientComponent,
        UserOrdersComponent,
        UserComponent,
        UserOffersToMeComponent,
    ],
    imports: [
        MaterialModule,
        ReactiveFormsModule,
        MatRadioModule,
        MatTableModule,
        CommonModule,
        MatExpansionModule,
        RouterModule.forChild(routs),
        MatSelectModule,
    ],
    exports: [
        UserLoginComponent,
        UserRegisterAsClientComponent,
        MaterialModule,
        CommonModule,
        RouterModule,
        MatSelectModule,
    ]
})
export class RootUserModule{}