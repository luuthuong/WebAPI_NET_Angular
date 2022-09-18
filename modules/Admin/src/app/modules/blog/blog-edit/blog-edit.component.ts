import {
	Component,
	OnInit,
	SecurityContext,
	ViewEncapsulation,
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from '@app/service/blog/blog.service';
import { Basecomponent } from '@app/shared/component/basecomponent';
import { CheckErrorStateMatcher } from '@app/shared/helper/state-input.helper';
import { CreateNewPostRequest } from '@app/shared/model/blog/createNewPost.model';
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
	public blogId?: string | number;
	public editorFormControl = new FormGroup({
		title: new FormControl('', [Validators.required]),
		category: new FormControl([]),
		metaTitle: new FormControl('', [Validators.required]),
		slug: new FormControl('', [Validators.required]),
		parentId: new FormControl(''),
		ckeditorContent: new FormControl('', [Validators.required]),
		summary: new FormControl(''),
	});
	public matcherInput = new CheckErrorStateMatcher();

	constructor(
		private sanitize: DomSanitizer,
		private router: Router,
		private route: ActivatedRoute,
		private blogService: BlogService,
		private spinner: NgxSpinnerService,
		private snackBar: MatSnackBar
	) {
		super();
		this.route.params
			.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe((param) => {
				this.blogId = param['id'];
			});
	}

	ngOnInit(): void {}

	public sanitizeHtmlContent(htmlString: any): SafeHtml | null {
		return this.sanitize.sanitize(SecurityContext.HTML, htmlString);
	}

	public createPost() {
		if (this.editorFormControl.invalid) return;
		const rawValue = this.editorFormControl.getRawValue();
		const request: CreateNewPostRequest = {
			title: rawValue.title || '',
			metaTitle: rawValue.metaTitle || '',
			slug: rawValue.slug || '',
			content: rawValue.ckeditorContent|| '',
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
}
