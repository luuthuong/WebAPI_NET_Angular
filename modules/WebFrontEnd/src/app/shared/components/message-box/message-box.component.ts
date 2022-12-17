import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MessageBoxConfig } from 'app/shared/model/message-box-config.model';
import { SharedCommonModule } from 'app/shared/shared-common.module';
import { BaseComponent } from '../base.component';

@Component({
	selector: 'app-message-box',
	template: `
		<div class="message-box">
			<h1 mat-dialog-title>
				{{ data.title ? data.title : 'Message' }}
			</h1>
			<mat-dialog-content>
				<div *ngIf="data.innerHTMLContent">
					{{ data.innerHTMLContent }}
				</div>
				<div *ngIf="data.message">
					{{ data.message }}
				</div>
			</mat-dialog-content>
			<mat-dialog-actions align="end">
				<button mat-button mat-dialog-close>
          Cancel
				</button>
			</mat-dialog-actions>
		</div>
	`,
	styleUrls: ['./message-box.component.scss'],
	standalone: true,
	imports: [
    SharedCommonModule,
    CommonModule
  ],
})
export class MessageBoxComponent extends BaseComponent implements OnInit {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: MessageBoxConfig
  ) { 
    super();
  }

  ngOnInit(): void {
  }
}
