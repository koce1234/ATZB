import { NgModule } from '@angular/core';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserRegisterAsClientComponent } from './user-register-as-client/user-register-as-client.component';
import { UserRegisterAsPerformerComponent } from './user-register-as-performer/user-register-as-performer.component';
import { MaterialModule } from '../MaterialModule';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatRadioModule } from '@angular/material/radio';
import { UserOrdersComponent } from './user-orders/user-orders.component';
import { UserComponent } from './user/user.component';
import { UserOffersToMeComponent } from './user-offers-to-me/user-offers-to-me.component';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';

@NgModule({
    declarations:[
        UserLoginComponent,
        UserRegisterAsClientComponent,
        UserRegisterAsPerformerComponent,
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
    ],
    exports: [
        UserLoginComponent,
        UserRegisterAsClientComponent,
        UserRegisterAsPerformerComponent,
        MaterialModule,
        CommonModule,
    ]
})
export class UserModule{}