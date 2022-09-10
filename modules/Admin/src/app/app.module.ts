import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClient, HttpClientModule, HttpHeaders, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '@enviroment/environment';
import { LocalStorageModule, LocalStorageService } from 'angular-2-local-storage';
import { NgxSpinnerModule } from 'ngx-spinner';
import { take } from 'rxjs';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material/material.module';
import { NotfoundComponent } from './modules/notfound/notfound.component';
import { IAuthLogginRequest, IAuthorModel } from './shared/model/auth/auth.model';
import { TokenService } from './service/token.service';

@NgModule({
  declarations: [
    AppComponent,
    NotfoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
	HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
	LocalStorageModule.forRoot({
		prefix:'',
		storageType: 'localStorage'
	}),
  ],
  providers: [
	{
		provide: APP_INITIALIZER,
		useFactory: initializeAppFactory,
		deps: [HttpClient],
		multi: true
	}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

function initializeAppFactory(httpClient: HttpClient){
	const tokenStorage = new LocalStorageService({prefix:'',storageType:'localStorage'})
	return () => httpClient.post(environment.baseURL+'auth/login',{
		userName: 'thuong',
		password: '123'
	} as IAuthLogginRequest,{
		headers: new HttpHeaders()
	})
	.pipe(take(1)).subscribe((result)=>{
		const auth = result as IAuthorModel
		tokenStorage.add(environment.TOKEN_KEY,auth.token.accessToken)
		tokenStorage.add(environment.TOKEN_REFRESH,auth.token.refreshToken)
	});
}
