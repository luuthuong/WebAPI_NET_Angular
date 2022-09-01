import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { ForgotpwdComponent } from './forgotpwd/forgotpwd.component';


@NgModule({
  declarations: [
    LoginComponent,
    ForgotpwdComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
