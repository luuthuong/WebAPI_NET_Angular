import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SwiperModule } from 'swiper/angular';
import { NgParticlesModule } from 'ng-particles';


@NgModule({
  declarations: [],
  imports: [
    // CommonModule,
    SwiperModule,
    NgParticlesModule

  ],
  exports:[
    SwiperModule,
    NgParticlesModule
  ]
})
export class SharedCommonModule { }
