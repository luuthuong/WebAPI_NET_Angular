import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatChipsModule } from '@angular/material/chips';
import { MatRippleModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { NgParticlesModule } from 'ng-particles';
import { SwiperModule } from 'swiper/angular';
import { ButtonOptionGroupComponent } from './components/button-option-group/button-option-group.component';
import { ConfirmDialogComponent } from './components/dialog/confirm-dialog/confirm-dialog.component';
import { OverviewProductDialogComponent } from './components/dialog/overview-product-dialog/overview-product-dialog.component';
import { WindowScrollDirective } from './directive/window-scroll.directive';
import { DatePipe } from './pipe/date.pipe';
import { TopbarComponent } from './components/topbar/topbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { RouterModule } from '@angular/router';
import { LoadingService } from 'app/services/loading.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { DEFAULT_TIMEOUT, TimeoutInterceptor } from './interceptors/timeout.interceptor';
import { environment } from '@env/environment';
import { MessageBoxComponent } from './components/message-box/message-box.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
const MaterialModule = [
	MatButtonModule,
	MatIconModule,
	MatRippleModule,
	MatDialogModule,
	MatButtonToggleModule,
	MatChipsModule,
	MatInputModule,
	MatDividerModule,
	MatSnackBarModule
];

@NgModule({
	declarations: [
		WindowScrollDirective,
		DatePipe,
		TopbarComponent,
		FooterComponent,
	],
	imports: [
		RouterModule,
		CommonModule,
		...MaterialModule,
		SwiperModule,
		NgParticlesModule,
		FormsModule,
		ReactiveFormsModule,
	],
	exports: [
		SwiperModule,
		NgParticlesModule,
		WindowScrollDirective,
		...MaterialModule,
		DatePipe,
		FooterComponent,
		TopbarComponent
	],
	providers:[
		LoadingService,
		{
			provide: HTTP_INTERCEPTORS,
			useClass: LoadingInterceptor,
			multi: true
		},
		[
			{
				provide: HTTP_INTERCEPTORS,
				useClass: TimeoutInterceptor,
				multi: true
			}
		],
		[
			{
				provide: DEFAULT_TIMEOUT,
				useValue: environment.defaultTimeOut
			}
		]
	],
	schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class SharedCommonModule {}
