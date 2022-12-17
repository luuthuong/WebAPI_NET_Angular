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
import { BLOG_CARD, PRODUCT_FEATURED, PRODUCT_PROMOTION } from './common/landing.template.constant';
import { INavigateToolbar } from 'app/shared/model/navigate-fragment.model';
import { BREAKPOINTS_SWIPER, BREAKPOINTS_SWIPER_PRIMARY } from 'app/shared/constants/swiper-config.constants';
import * as AOS from 'aos';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog'
import { OverviewProductDialogComponent } from 'app/shared/components/dialog/overview-product-dialog/overview-product-dialog.component';

SwiperCore.use([Pagination, Navigation, Mousewheel, Keyboard]);
@Component({
	selector: 'app-landing',
	templateUrl: './landing.component.html',
	styleUrls: ['./landing.component.scss'],
	encapsulation: ViewEncapsulation.None,
})
export class LandingComponent extends BaseComponent implements OnInit {
	particleConfig = PARTICLE_CONFIG;
	subTitleArr = ('Technology').split('').map((x) => (x = x === ' ' ? '&nbsp;' : x));
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
	productFeatured:IProductModel[] = PRODUCT_FEATURED;
	blogItems: IBlogModel[] = BLOG_CARD;
	isChangeToolbar: boolean = false;
	currentFragment: string = '';
	breakpointSwiper = BREAKPOINTS_SWIPER;
	breakpointSwiperBlog = BREAKPOINTS_SWIPER_PRIMARY;

	constructor(
		private eleRef: ElementRef,
		private router: Router,
		private location: Location,
		private dialog: MatDialog
	) {
		super();
		fromEvent(window, 'scroll')
			.pipe(takeUntil(this.ngUnsubscribe))
			.subscribe((e: Event) => {
				const positionY = window.scrollY;
				const homeEl = this.eleRef.nativeElement.querySelector(
					'#home'
				) as Element;
				this.isChangeToolbar =
					positionY > homeEl.clientHeight - 65 ;
			});

		this.router.events
			.pipe(takeUntil(this.ngUnsubscribe))
			.subscribe((result) => {
				if (result instanceof NavigationEnd) {
					this.currentFragment = this.router.parseUrl(result.url).fragment || 'home';
					// const element = this.eleRef.nativeElement.querySelector(`#${this.currentFragment}`) as Element;
					// console.log(element)
					// if(element){
					// 	element.scrollIntoView({
					// 		behavior: 'smooth',
					// 		block: 'start'
					// 	})
					// }
				}
		});
	}

	ngOnInit(): void {
		AOS.init({
			once: true
		});
	}

	particlesLoaded(container: Container): void {
		this.eleRef.nativeElement.querySelector('canvas').style.position =
			'absolute';
		this.eleRef.nativeElement.querySelector('canvas').style.zIndex = '0';
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

	openDialogOverViewProduct(){
		this.isChangeToolbar = true;
		const dialogConfig : MatDialogConfig = {
			maxHeight:'80vh',
			maxWidth: '840px',
			panelClass: 'panel-dialog-product'
		}
		const dialogRef = this.dialog.open(OverviewProductDialogComponent,dialogConfig)
		dialogRef.afterClosed()
		.pipe(takeUntil(this.ngUnsubscribe))
		.subscribe(result =>{
			this.isChangeToolbar= false;
		})
	}
}
