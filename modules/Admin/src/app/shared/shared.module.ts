import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmDialogComponent } from './component/confirm-dialog/confirm-dialog.component';
import { MaterialModule } from '@app/material/material.module';
import { ClickOutsideDirective } from './directive/click-outside.directive';
import { AutoFocusDirective } from './directive/auto-focus.directive';

@NgModule({
	declarations: [ConfirmDialogComponent, ClickOutsideDirective, AutoFocusDirective],
	imports: [CommonModule, MaterialModule],
	exports: [ConfirmDialogComponent],
})
export class SharedModule {}
