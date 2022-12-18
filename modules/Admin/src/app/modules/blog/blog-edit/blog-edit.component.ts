import {
	Component,
	OnInit,
	SecurityContext,
	ViewEncapsulation,
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from '@app/service/blog/blog.service';
import { RoutingService } from '@app/service/routing.service';
import { Basecomponent } from '@app/shared/component/basecomponent';
import { APP_ROUTE, BLOG_ROUTE } from '@app/shared/constant/routing.constant';
import { CheckErrorStateMatcher } from '@app/shared/helper/state-input.helper';
import { CreateNewPostRequest } from '@app/shared/model/blog/createNewPost.model';
import { IUpdatePostModelRequest } from '@app/shared/model/blog/updatePostRequest.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { takeUntil } from 'rxjs';
@Component({
	selector: 'app-blog-edit',
	templateUrl: './blog-edit.component.html',
	styleUrls: ['./blog-edit.component.scss'],
	encapsulation: ViewEncapsulation.None,
	providers: [],
})
export class BlogEditComponent extends Basecomponent implements OnInit {
	public blogId?: string;
	public editorFormControl = new FormGroup({
		title: new FormControl('', [Validators.required]),
		category: new FormControl([]),
		metaTitle: new FormControl('', [Validators.required]),
		slug: new FormControl('', [Validators.required]),
		parentId: new FormControl(''),
		ckeditorContent: new FormControl('', [Validators.required]),
		summary: new FormControl(''),
		published: new FormControl(false)
	});
	public matcherInput = new CheckErrorStateMatcher();

	constructor(
		private sanitize: DomSanitizer,
		private route: ActivatedRoute,
		private blogService: BlogService,
		private spinner: NgxSpinnerService,
		private snackBar: MatSnackBar,
		private routingService: RoutingService,
		private dialog: MatDialog
	) {
		super();
		this.route.params
			.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe((param) => {
				this.blogId = param['id'];
				if (this.blogId) {
					this.blogService
						.getPostById(this.blogId)
						.pipe(takeUntil(this.ngUnsubcribe))
						.subscribe((result) => {
							this.editorFormControl
								.get('title')
								?.patchValue(result.title);
							this.editorFormControl
								.get('metaTitle')
								?.patchValue(result.metaTitle);
							this.editorFormControl
								.get('slug')
								?.patchValue(result.slug);
							this.editorFormControl
								.get('ckeditorContent')
								?.patchValue(result.content);
							this.editorFormControl
								.get('summary')
								?.patchValue(result.summary);
							this.editorFormControl
								.get('published')
								?.patchValue(result.published);
						});
				}
			});
	}

	ngOnInit(): void {}

	public sanitizeHtmlContent(htmlString: any): SafeHtml | null {
		return this.sanitize.sanitize(SecurityContext.HTML, htmlString);
	}

	public updatePost() {
		if (this.editorFormControl.invalid) return;
		if (!this.blogId) {
			this._createPost();
			return;
		}
		this._updatePost();
	}

	private _createPost() {
		const rawValue = this.editorFormControl.getRawValue();
		const request: CreateNewPostRequest = {
			title: rawValue.title || '',
			metaTitle: rawValue.metaTitle || '',
			slug: rawValue.slug || '',
			content: rawValue.ckeditorContent || '',
			summary: rawValue.summary || '',
		};
		this.spinner.show();
		this.blogService
			.createNewPost(request)
			.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe({
				next: (result) => {
					this.spinner.hide();
					this.snackBar.open('Success', 'Cancel');
				},
				error: (err) => {
					this.spinner.hide();
					this.snackBar.open('Error', 'Cancel');
				},
			});
	}
	private _updatePost() {
		if (!this.blogId) return;
		const rawValue = this.editorFormControl.getRawValue();
		const request: IUpdatePostModelRequest = {
			title: rawValue.title || '',
			metaTitle: rawValue.metaTitle || '',
			slug: rawValue.slug || '',
			content: rawValue.ckeditorContent || '',
			summary: rawValue.summary || '',
			published: rawValue.published ||false,
		};
		this.spinner.show();
		this.blogService
			.updatePostById(this.blogId, request)
			.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe((result) => {
				this.spinner.hide();
				this.snackBar.open('Success', 'Cancel');
			},()=>{
				this.spinner.hide();
				this.snackBar.open('Error', 'Cancel');
			});
	}

	navigateToBlogHome(){
		this.routingService.navigateTo([APP_ROUTE.BLOG,BLOG_ROUTE.OVERVIEW])
	}
}
