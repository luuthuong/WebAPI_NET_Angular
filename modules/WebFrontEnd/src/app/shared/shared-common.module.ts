import {
	CUSTOM_ELEMENTS_SCHEMA,
	NgModule,
	NO_ERRORS_SCHEMA,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { SwiperModule } from 'swiper/angular';
import { NgParticlesModule } from 'ng-particles';
import { WindowScrollDirective } from './directive/window-scroll.directive';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatRippleModule } from '@angular/material/core';
import { DatePipe } from './pipe/date.pipe';
import { OverviewProductDialogComponent } from './components/dialog/overview-product-dialog/overview-product-dialog.component';
import { ConfirmDialogComponent } from './components/dialog/confirm-dialog/confirm-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { ButtonOptionGroupComponent } from './components/button-option-group/button-option-group.component';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatChipsModule } from '@angular/material/chips';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import {MatDividerModule} from '@angular/material/divider';
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
