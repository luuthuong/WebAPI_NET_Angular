import {
	Component,
	OnInit,
	SecurityContext,
	ViewEncapsulation,
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { Basecomponent } from '@app/shared/component/basecomponent';
import { CheckErrorStateMatcher } from '@app/shared/helper/state-input.helper';
import { takeUntil } from 'rxjs';
@Component({
	selector: 'app-blog-edit',
	templateUrl: './blog-edit.component.html',
	styleUrls: ['./blog-edit.component.scss'],
	encapsulation: ViewEncapsulation.None,
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
		private route: ActivatedRoute
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
	}

	ngOnInit(): void {}

	public sanitizeHtmlContent(htmlString: any): SafeHtml | null {
		return this.sanitize.sanitize(SecurityContext.HTML, htmlString);
	}

	onChanged($event: any) {
		console.log('on change', $event);
	}
}
