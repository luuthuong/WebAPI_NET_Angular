import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BaseComponent } from '../../base.component';
import SwiperCore, { Keyboard, Mousewheel, Navigation, Pagination } from 'swiper';
import { OVERVIEW_PRODDUCT_DIALOG } from 'app/modules/landing/common/landing.template.constant';
import { IProductModel } from 'app/modules/shop/model/product.model';
SwiperCore.use([Pagination, Navigation, Mousewheel, Keyboard]);

@Component({
  selector: 'app-overview-product-dialog',
  templateUrl: './overview-product-dialog.component.html',
  styleUrls: ['./overview-product-dialog.component.scss']
})

export class OverviewProductDialogComponent extends BaseComponent implements OnInit {
  dataOvervviewProduct: IProductModel = OVERVIEW_PRODDUCT_DIALOG[0];
  constructor(
	private dialogRef: MatDialogRef<OverviewProductDialogComponent>
  ) {
	super();
	console.log(this.dataOvervviewProduct)
  }

  ngOnInit(): void {
  }

}
