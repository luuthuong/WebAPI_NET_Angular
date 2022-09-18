import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmDialogComponent } from './component/confirm-dialog/confirm-dialog.component';
import { MaterialModule } from '@app/material/material.module';

@NgModule({
	declarations: [ConfirmDialogComponent],
	imports: [CommonModule, MaterialModule],
	exports: [ConfirmDialogComponent],
})
export class SharedModule {}
