import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {
	HttpClientModule, HTTP_INTERCEPTORS
} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
	LocalStorageModule
} from 'angular-2-local-storage';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material/material.module';
import { NotfoundComponent } from './modules/notfound/notfound.component';
import { TokenService } from './service/token.service';

@NgModule({
	declarations: [AppComponent, NotfoundComponent],
	imports: [
		BrowserModule,
		AppRoutingModule,
		HttpClientModule,
		BrowserAnimationsModule,
		MaterialModule,
		NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
		LocalStorageModule.forRoot({
			prefix: '',
			storageType: 'localStorage',
		}),
	],
	providers: [
		{
			provide: HTTP_INTERCEPTORS,
			useClass: TokenService,
			multi: true,
		},
	],
	bootstrap: [AppComponent],
	schemas:[
		CUSTOM_ELEMENTS_SCHEMA
	]
})
export class AppModule {}
