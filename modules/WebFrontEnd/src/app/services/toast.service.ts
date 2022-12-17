import { Injectable } from '@angular/core';
import {
	MatSnackBar,
	MatSnackBarConfig,
	MatSnackBarHorizontalPosition,
	MatSnackBarVerticalPosition,
} from '@angular/material/snack-bar';
import { AppInjectorService } from './app-injector.service';

@Injectable({
	providedIn: 'root',
})
export class ToastService {
	static horizontalPosition: MatSnackBarHorizontalPosition = 'right';
	static verticalPosition: MatSnackBarVerticalPosition = 'top';
	static actionButtonLabel: string = 'Đóng';
	static action: boolean = true;
	static setAutoHide: boolean = true;
	static autoHideTiming: number = 2000;
	static snackBar: MatSnackBar = AppInjectorService.getService(MatSnackBar);

	static success(msg: string) {
		if (msg && typeof msg === 'string') {
			const config = new MatSnackBarConfig();
			config.verticalPosition = this.verticalPosition;
			config.horizontalPosition = this.horizontalPosition;
			config.duration = this.setAutoHide ? this.autoHideTiming : 0;
			config.panelClass = [
				'toast-success',
				'mat-snack-bar-container-custom',
			];
			this.snackBar.open(
				msg,
				this.action ? this.actionButtonLabel : undefined,
				config
			);
		}
	}

	static error(msg: string) {
		if (msg && typeof msg === 'string') {
			const config = new MatSnackBarConfig();
			config.verticalPosition = this.verticalPosition;
			config.horizontalPosition = this.horizontalPosition;
			config.duration = 0;
			config.panelClass = [
				'toast-error',
				'mat-snackbar-container-custom',
			];
			this.snackBar.open(
				msg,
				this.action ? this.actionButtonLabel : undefined,
				config
			);
		}
	}
}
