import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth/auth.component';
import { AuthGuard } from 'app/shared/guards/auth.guard';
import { JWT_OPTIONS } from '@auth0/angular-jwt';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from 'app/shared/interceptors/token.interceptor';
import { ErrorInterceptor } from 'app/shared/interceptors/error.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';


@NgModule({
  declarations: [
    AuthComponent,
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
  ],
  providers:[
    AuthGuard,
    {
      provide: JWT_OPTIONS,
      useValue: JWT_OPTIONS
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    },
  ]
})
export class AuthModule { }
