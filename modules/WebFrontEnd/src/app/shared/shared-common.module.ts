import { CommonModule } from '@angular/common';
import {
	CUSTOM_ELEMENTS_SCHEMA,
	NgModule
} from '@angular/core';
import { FormsModule } from '@angular/forms';
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
const MaterialModule = [
	MatButtonModule,
	MatIconModule,
	MatRippleModule,
	MatDialogModule,
	MatButtonToggleModule,
	MatChipsModule,
	MatInputModule,
	MatDividerModule
];

@NgModule({
	declarations: [
		WindowScrollDirective,
		DatePipe,
		OverviewProductDialogComponent,
		ConfirmDialogComponent,
		ButtonOptionGroupComponent,
  TopbarComponent,
  FooterComponent,
	],
	imports: [CommonModule, ...MaterialModule, SwiperModule, NgParticlesModule, FormsModule],
	exports: [
		SwiperModule,
		NgParticlesModule,
		WindowScrollDirective,
		...MaterialModule,
		DatePipe,
	],
	schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class SharedCommonModule {}
