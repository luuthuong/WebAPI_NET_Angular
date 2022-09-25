import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SwiperModule } from 'swiper/angular';
import { NgParticlesModule } from 'ng-particles';
import { WindowScrollDirective } from './directive/window-scroll.directive';


@NgModule({
  declarations: [
    WindowScrollDirective
  ],
  imports: [
    // CommonModule,
    SwiperModule,
    NgParticlesModule

  ],
  exports:[
    SwiperModule,
    NgParticlesModule,
    WindowScrollDirective
  ]
})
export class SharedCommonModule { }
