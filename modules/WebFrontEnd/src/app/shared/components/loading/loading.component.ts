import { AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { BaseComponent } from '../base.component';
import { takeUntil } from 'rxjs';
import { LoadingService } from 'app/services/loading.service';
@Component({
	selector: 'app-loading',
	standalone: true,
	template: `
    <div *ngIf="isShowLoading" class="loading-container">
    <div class="center">
        <mat-progress-spinner diameter=50
                              mode="indeterminate"
                              color="primary">
        </mat-progress-spinner>
    </div>
</div>
  `,
	styleUrls: ['./loading.component.scss'],
	imports: [
    CommonModule,
    MatProgressSpinnerModule
  ],
})
export class LoadingComponent extends BaseComponent implements AfterViewInit {
	isShowLoading = true;
    constructor(
        private loadingService: LoadingService,
        private cdRef: ChangeDetectorRef
    ) {
        super();
    }

    ngAfterViewInit(): void {
        this.loadingService.getStateLoading()
        .pipe(takeUntil(this.ngUnsubscribe))
        .subscribe((status: boolean) => {
            this.isShowLoading = status;
            this.cdRef.detectChanges();
        });
    }
}
