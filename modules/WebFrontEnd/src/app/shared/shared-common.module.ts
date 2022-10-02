import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SwiperModule } from 'swiper/angular';
import { NgParticlesModule } from 'ng-particles';
import { WindowScrollDirective } from './directive/window-scroll.directive';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon'
import {MatRippleModule} from '@angular/material/core';
import { DatePipe } from './pipe/date.pipe'
const MaterialModule = [
	MatButtonModule,
	MatIconModule,
	MatRippleModule
]

@NgModule({
	declarations: [WindowScrollDirective, DatePipe],
	imports: [
		// CommonModule,
		SwiperModule,
		NgParticlesModule,

	],
	exports: [SwiperModule, NgParticlesModule, WindowScrollDirective,...MaterialModule,DatePipe],
})
export class SharedCommonModule {}
