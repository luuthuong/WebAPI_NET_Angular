import { IProductModel } from './../shop/model/product.model';
import { Location } from '@angular/common';
import { Component, ElementRef, OnInit, ViewEncapsulation } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { BaseComponent } from '@shared/components/base.component';
import { PARTICLE_CONFIG } from '@shared/constants/particles.config';
import { fromEvent, takeUntil } from 'rxjs';
import { loadFull } from 'tsparticles';
import { Container, Engine } from 'tsparticles-engine';
import SwiperCore, { Pagination, Navigation ,Mousewheel, Keyboard} from "swiper";
import { IBlogModel } from 'app/shared/model/blog.model';
import { BLOG_CARD, PRODUCT_PROMOTION } from './common/landing.template.constant';
import { INavigateToolbar } from 'app/shared/model/navigate-fragment.model';
import { BREAKPOINTS_SWIPER, BREAKPOINTS_SWIPER_PRIMARY } from 'app/shared/constants/swiper-config.constants';
import * as AOS from 'aos';

SwiperCore.use([Pagination, Navigation, Mousewheel, Keyboard]);

@Component({
	selector: 'app-landing',
	templateUrl: './landing.component.html',
	styleUrls: ['./landing.component.scss'],
	encapsulation: ViewEncapsulation.None,
})
export class LandingComponent extends BaseComponent implements OnInit {
	particleConfig = PARTICLE_CONFIG;
	subTitleArr = ('A Moment Technology').split('').map((x) => (x = x === ' ' ? '&nbsp;' : x));
	navigateToolbar: INavigateToolbar[] = [
		{
			display: 'Trang chủ',
			fragment: 'home',
			order: 1
		},
		{
			display: 'Flash sale',
			fragment: 'promotion',
			order: 2
		},
		{
			display: 'Sản phẩm nổi bật',
			fragment: 'featured-product',
			order: 3
		},
		{
			display: 'Bài viết',
			fragment: 'blog',
			order: 4
		},
		{
			display: 'Liên hệ',
			fragment: 'contact',
			order: 6
		},
	];
	promotionProducts: IProductModel[] = PRODUCT_PROMOTION
	blogItems: IBlogModel[] = BLOG_CARD;

	isChangeToolbar: boolean = false;
	currentFragment: string = '';
	breakpointSwiper = BREAKPOINTS_SWIPER;
	breakpointSwiperBlog = BREAKPOINTS_SWIPER_PRIMARY;

	constructor(
		private el: ElementRef,
		private router: Router,
		private location: Location
	) {
		super();
		fromEvent(window, 'scroll')
			.pipe(takeUntil(this.ngUnSubcribe))
			.subscribe((e: Event) => {
				const positionY = window.scrollY;
				const homeEl = this.el.nativeElement.querySelector(
					'#home'
				) as Element;
				this.isChangeToolbar =
					positionY > homeEl.clientHeight - 65 &&
					!!this.router.parseUrl(this.router.url).fragment;
			});

		this.router.events
			.pipe(takeUntil(this.ngUnSubcribe))
			.subscribe((result) => {
				if (result instanceof NavigationEnd) {
					this.currentFragment = this.router.parseUrl(result.url).fragment || 'home';
				}
		});
	}

	ngOnInit(): void {
		AOS.init();
	}

	particlesLoaded(container: Container): void {
		this.el.nativeElement.querySelector('canvas').style.position =
			'absolute';
		this.el.nativeElement.querySelector('canvas').style.zIndex = '0';
	}

	async particlesInit(engine: Engine): Promise<void> {
		await loadFull(engine);
	}
	getYPosition(e: any): number {
		return (e.target as Element).scrollTop;
	}

	onSwiper($event:any){

	}

	onSlideChange($event:any){

	}
}
