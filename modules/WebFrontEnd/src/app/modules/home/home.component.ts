import SwiperCore, { Keyboard, Mousewheel, Navigation, Pagination  } from 'swiper';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';

SwiperCore.use([Pagination, Navigation, Mousewheel, Keyboard]);
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  onSwiper(swiper:any) {
    console.log(swiper);
  }
  onSlideChange() {
    console.log('slide change');
  }

}
