import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
	selector: 'app-confirm-dialog',
	templateUrl: './confirm-dialog.component.html',
	styleUrls: ['./confirm-dialog.component.scss'],
})
export class ConfirmDialogComponent implements OnInit {
	constructor(
		private dialogRef : MatDialogRef<ConfirmDialogComponent>
	) {}

	ngOnInit(): void {}

	public close(){
		this.dialogRef.close();
	}
}
