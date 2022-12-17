import { BREAKPOINT_SWIPER_THUMB } from './../../../constants/swiper-config.constants';
import { IChipOptionModel } from './../../../model/chip-group-option.model';
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
import { ButtonGroupTypeEnum } from 'app/shared/enum/button-group-type.enum';
import { SwiperModule } from 'swiper/angular';
import { MatIconModule } from '@angular/material/icon';
import { ButtonOptionGroupComponent } from '../../button-option-group/button-option-group.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
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
	standalone: true,
	imports:[
		SwiperModule,
		MatIconModule,
		ButtonOptionGroupComponent,
		FormsModule,
		CommonModule
	]
})
export class OverviewProductDialogComponent
	extends BaseComponent
	implements OnInit
{
	thumbsSwiper: any;
	dataOvervviewProduct: IProductModel = OVERVIEW_PRODDUCT_DIALOG[0];
	quantity: number = 0;
	dataChip: IChipOptionModel[] = [
		{
			name: 'Blue',
			value: '1',
			disable: false,
		},
		{
			name: 'Red',
			value: '2',
			disable: true,
		},
		{
			name: 'Orange',
			value: '3',
			disable: false,
		},
	];
	dataCircleOption: IChipOptionModel[] = [
		{
			name: 'Blue',
			value: '1',
			disable: false,
			color: '#F7971E'
		},
		{
			name: 'Red',
			value: '2',
			disable: false,
			color:'#8E2DE2'
		},
		{
			name: 'Orange',
			value: '3',
			disable: false,
			color: '#021B79'
		},
	];
	enumTypeGroup = ButtonGroupTypeEnum;
	breakpointThumb =  BREAKPOINT_SWIPER_THUMB

	constructor(
		private dialogRef: MatDialogRef<OverviewProductDialogComponent>
	) {
		super();
	}

	ngOnInit(): void {}

	plusQuantity(){
		this.quantity += 1;
		console.log(this.quantity)
	}
	minusQuantity(){
		this.quantity = this.quantity > 0 ? this.quantity - 1 : 0;
		console.log(this.quantity)
	}
}
