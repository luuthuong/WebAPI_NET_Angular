import { TokenInterceptor } from './shared/interceptors/token.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CUSTOM_ELEMENTS_SCHEMA, Injector, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AppInjectorService } from './services/app-injector.service';
import { ToastService } from './services/toast.service';
import { SharedCommonModule } from './shared/shared-common.module';
import { AuthGuard } from './shared/guards/auth.guard';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './services/auth.service';
import { ErrorInterceptor } from './shared/interceptors/error.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoginComponent } from './auth/login/login.component';
import { LoadingInterceptor } from './shared/interceptors/loading.interceptor';
@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    SharedCommonModule,
    NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
    LoginComponent
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
  ],
  providers: [
    JwtHelperService,
    AuthService,
    AuthGuard,
    ToastService,
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
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingInterceptor,
      multi: true
    }

  ],
  bootstrap: [AppComponent],
  schemas:[
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class AppModule {

  constructor(
    private injector: Injector
  ) {
    AppInjectorService.setInjector(this.injector);
  }
}
