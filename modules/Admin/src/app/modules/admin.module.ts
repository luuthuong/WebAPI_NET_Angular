import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { MaterialModule } from '@app/material/material.module';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
	declarations: [AdminComponent],
	imports: [
		CommonModule,
		AdminRoutingModule,
		MaterialModule,
		NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
	],
})
export class AdminModule {}
