import { NgModule } from '@angular/core';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserRegisterAsClientComponent } from './user-register-as-client/user-register-as-client.component';
import { UserRegisterAsPerformerComponent } from './user-register-as-performer/user-register-as-performer.component';
import { UserClientComponent } from './user-client/user-client.component';
import { UserPerformerComponent } from './user-performer/user-performer.component';
import { MaterialModule } from '../MaterialModule';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatRadioModule } from '@angular/material/radio';

@NgModule({
    declarations:[
        UserLoginComponent,
        UserRegisterAsClientComponent,
        UserRegisterAsPerformerComponent,
        UserClientComponent,
        UserPerformerComponent
    ],
    imports: [
        MaterialModule,
        ReactiveFormsModule,
        MatRadioModule
    ],
    exports: [
        UserLoginComponent,
        UserRegisterAsClientComponent,
        UserRegisterAsPerformerComponent,
        UserClientComponent,
        UserPerformerComponent,
        MaterialModule

    ]
})
export class UserModule{}