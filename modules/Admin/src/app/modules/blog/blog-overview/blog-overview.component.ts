import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { BlogService } from '@app/service/blog/blog.service';
import { RoutingService } from '@app/service/routing.service';
import { Basecomponent } from '@app/shared/component/basecomponent';
import { ConfirmDialogComponent } from '@app/shared/component/confirm-dialog/confirm-dialog.component';
import { APP_ROUTE, BLOG_ROUTE } from '@app/shared/constant/routing.constant';
import { BlogModel } from '@app/shared/model/blog/blogModel';
import { IDeletePostModelRequest } from '@app/shared/model/blog/deletePostRequest.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { takeUntil } from 'rxjs';

@Component({
	selector: 'app-blog-overview',
	templateUrl: './blog-overview.component.html',
	styleUrls: ['./blog-overview.component.scss'],
	encapsulation: ViewEncapsulation.None
})
export class BlogOverviewComponent extends Basecomponent implements OnInit {
	public blogs = new Array(50).fill(0);
	public appRoute = APP_ROUTE;
	public blogRoute = BLOG_ROUTE;

	public blogsList :BlogModel[] = [];
	public postSelected: string[] = [];
	public isSelectedAllPost: boolean =false;
	constructor(
		private routingService: RoutingService,
		private blogService: BlogService,
		private spinner: NgxSpinnerService,
		private dialog: MatDialog
	) {
		super();
	}

	ngOnInit(): void {
		this._getAllPost();
	}

	public navigateTo(path: string[]) {
		this.routingService.navigateTo(path);
	}

	private _getAllPost() {
		this.spinner.show();
		this.blogService
			.getAllPost()
			.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe({
				next: (result) => {
					this.spinner.hide();
					this.blogsList = result;
				},
				error:()=>{
					this.spinner.hide();
				}
			});
	}

	onSelectedChange(id:string){
		this.postSelected.includes(id) ?
			this.postSelected.splice(this.postSelected.findIndex(x=>x ===id),1)
			: this.postSelected.push(id);
	}

	public deletePost(ids: string[]){
		const request: IDeletePostModelRequest = {
			ids :ids,
			includeChildren: false
		}

		const dialogRef = this.dialog.open(ConfirmDialogComponent,{
			width: '330px'
		})

		dialogRef.afterClosed()
		.pipe(takeUntil(this.ngUnsubcribe))
		.subscribe(res=>{
			if(res){
				this.spinner.show();
				this.blogService.deletePost(request)
				.pipe(takeUntil(this.ngUnsubcribe))
				.subscribe(result=>{
					this.spinner.hide();
					this._getAllPost();
				})
			}
		})
	}

	checkIndeterminate(){
		return this.postSelected.length < this.blogsList.length && this.postSelected.length>0
	}

	selectAll(isChecked: boolean){
		this.blogsList.forEach(x=>x.isSelected = isChecked);
		this.postSelected  = this.blogsList.filter(x=>x.isSelected).map(x=>x.id);
	}
}
