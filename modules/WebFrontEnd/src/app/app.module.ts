import { ToastService } from './services/toast.service';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule, Injector } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SharedCommonModule } from './shared/shared-common.module';
import { MessageBoxComponent } from "./shared/components/message-box/message-box.component";
import { AppInjectorService } from './services/app-injector.service';

@NgModule({
    declarations: [AppComponent],
    providers: [],
    bootstrap: [AppComponent],
    schemas: [],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HttpClientModule,
        SharedCommonModule,
        MessageBoxComponent
    ]
})
export class AppModule {
	constructor(private injector: Injector){
		AppInjectorService.setInjector(this.injector);
	}
}
