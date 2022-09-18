import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BlogService } from '@app/service/blog/blog.service';
import { RoutingService } from '@app/service/routing.service';
import { Basecomponent } from '@app/shared/component/basecomponent';
import { BlogModel } from '@app/shared/model/blog/blogModel';
import { takeUntil } from 'rxjs';

@Component({
	selector: 'app-blog-detail',
	templateUrl: './blog-detail.component.html',
	styleUrls: ['./blog-detail.component.scss'],
})
export class BlogDetailComponent extends Basecomponent implements OnInit {

	private _idPost: string = '';
	public blogDetail?: BlogModel
	constructor(
		private blogService: BlogService,
		private routingService: RoutingService,
		private activatedRoute: ActivatedRoute
	) {
		super();
		this.activatedRoute.params
			.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe(result=>{
				console.log(result)
				this._idPost = result['id'];
			})
	}

	ngOnInit(): void {
		this.getDetailPost();
	}

	private getDetailPost(){
		if(this._idPost){
			this.blogService.getPostById(this._idPost)
			.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe(result=>{
				this.blogDetail = result;
			})
		}
	}
}
