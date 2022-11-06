import SwiperCore, { Autoplay, Keyboard, Mousewheel, Navigation, Pagination  } from 'swiper';
import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { SLIDE_DATA_TEMPLATE } from './home-data.template';

SwiperCore.use([Pagination, Navigation, Mousewheel, Keyboard, Autoplay]);
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class HomeComponent implements OnInit {
  @ViewChild('homeSlide',{static: true}) homeSlide: any ;
  dataSlide : any = SLIDE_DATA_TEMPLATE
  constructor() { }

  ngOnInit(): void {
    console.log(this.homeSlide)
  }

  onSwiper(swiper:any) {
    console.log(swiper);
  }
  onSlideChange() {
    console.log('slide change');
  }

}
