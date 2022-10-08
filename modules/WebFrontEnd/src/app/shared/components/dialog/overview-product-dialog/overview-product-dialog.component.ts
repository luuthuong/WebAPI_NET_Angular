import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { OVERVIEW_PRODDUCT_DIALOG } from '@modules/landing/common/landing.template.constant';
import { IProductModel } from 'app/modules/shop/model/product.model';
import SwiperCore, {
	FreeMode,
	Grid,
	Keyboard,
	Mousewheel,
	Navigation,
	Pagination,
	Thumbs,
} from 'swiper';
import { BaseComponent } from '../../base.component';
SwiperCore.use([
	Grid,
	Pagination,
	Navigation,
	Keyboard,
	Mousewheel,
	Thumbs,
	FreeMode,

]);

@Component({
	selector: 'app-overview-product-dialog',
	templateUrl: './overview-product-dialog.component.html',
	styleUrls: ['./overview-product-dialog.component.scss'],
	encapsulation: ViewEncapsulation.None,
})
export class OverviewProductDialogComponent
	extends BaseComponent
	implements OnInit
{
	thumbsSwiper: any;
	dataOvervviewProduct: IProductModel = OVERVIEW_PRODDUCT_DIALOG[0];
	constructor(
		private dialogRef: MatDialogRef<OverviewProductDialogComponent>
	) {
		super();
	}

	ngOnInit(): void {}
}
