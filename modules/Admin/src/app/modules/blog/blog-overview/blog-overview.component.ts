import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ViewEncapsulation } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { BlogService } from '@app/service/blog/blog.service';
import { RoutingService } from '@app/service/routing.service';
import { TokenService } from '@app/service/token.service';
import { Basecomponent } from '@app/shared/component/basecomponent';
import { APP_ROUTE, BLOG_ROUTE } from '@app/shared/constant/routing.constant';
import { BlogOverviewModel } from '@app/shared/model/blog/blogModel';
import { takeUntil } from 'rxjs';

@Component({
	selector: 'app-blog-overview',
	templateUrl: './blog-overview.component.html',
	styleUrls: ['./blog-overview.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers:[
	{
		provide: HTTP_INTERCEPTORS,
		useClass: TokenService,
		multi: true
	}
  ]
})
export class BlogOverviewComponent extends Basecomponent implements OnInit {
	public blogs = new Array(50).fill(0);
	public appRoute = APP_ROUTE;
	public blogRoute = BLOG_ROUTE;
  public selectedItem: string[] = [];


  public data: BlogOverviewModel ={
    id: '1',
    author: 'Thuong',
    category: 'Fashion',
    published: true,
    createdDate: new Date(),
    updatedDate: new Date(),
    srcImage: 'https://images.pexels.com/photos/12908191/pexels-photo-12908191.jpeg?auto=compress&cs=tinysrgb&w=1600&lazy=load',
    tag:'No tag',
    title:'Take your best fur friend on a road trip and have fun'
  }
	constructor(
		private routingService: RoutingService,
		private blogService: BlogService
		) {
		super();
	}

	ngOnInit(): void {
		this._getAllPost()
	}

	public navigateTo(path: string[]) {
		this.routingService.navigateTo(path);
	}

	private _getAllPost(){
		this.blogService.getAllPost()
			.pipe(takeUntil(this.ngUnsubcribe))
			.subscribe({
			next:(result)=>{
				console.log(result,12)
			}
		})
	}
}
