import { HTTP_INTERCEPTORS } from '@angular/common/http';
import {
	Component,
	OnInit,
	SecurityContext,
	ViewEncapsulation,
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from '@app/service/blog/blog.service';
import { TokenStorageService } from '@app/service/token-storage.service';
import { TokenService } from '@app/service/token.service';
import { Basecomponent } from '@app/shared/component/basecomponent';
import { CheckErrorStateMatcher } from '@app/shared/helper/state-input.helper';
import { CreateNewPostRequest } from '@app/shared/model/blog/createNewPost.model';
import { environment } from '@enviroment/environment';
import { takeUntil } from 'rxjs';
@Component({
	selector: 'app-blog-edit',
	templateUrl: './blog-edit.component.html',
	styleUrls: ['./blog-edit.component.scss'],
	encapsulation: ViewEncapsulation.None
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
		private tokenStorageService : TokenStorageService
	) {
		super();
		this.route.params
			.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe((param) => {
				this.blogId = param['id'];
			});

		this.editorFormControl
			.get('ckeditorContent')
			?.valueChanges.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe((res) => {
				console.log(res);
			});
		console.log(this.tokenStorageService.getToken())
	}

	ngOnInit(): void {}

	public sanitizeHtmlContent(htmlString: any): SafeHtml | null {
		return this.sanitize.sanitize(SecurityContext.HTML, htmlString);
	}

	onChanged($event: any) {
		console.log('on change', $event);
	}

	public createPost(){
		if(this.editorFormControl.invalid)
			return;
		const rawValue = this.editorFormControl.getRawValue();
		const request: CreateNewPostRequest = {
			title: rawValue.title || '',
			metaTitle: rawValue.metaTitle || '',
			slug: rawValue.slug || '',
			content:  '342234',
			summary: rawValue.summary || ''
		}
		this.blogService.createNewPost(request)
			.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe({
				next:(result)=>{
					console.log(result)
				}
			})

	}
}
