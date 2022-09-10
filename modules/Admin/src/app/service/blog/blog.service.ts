import { Injectable } from '@angular/core';
import { HttpBaseService } from '../http-base.service';
import { CreateNewPostRequest } from '@app/shared/model/blog/createNewPost.model';
import { BlogModel } from '@app/shared/model/blog/blogModel';
import { Observable } from 'rxjs';
@Injectable({
	providedIn: 'root',
})
export class BlogService extends HttpBaseService {
	private _path = 'BlogPost/'
	public createNewPost(request: CreateNewPostRequest): Observable<any>{
		return this.post(this._path + 'Create',request);
	}

	public getAllPost():Observable<BlogModel>{
		return this.get(this._path + 'getAllPost');
	}

	public getPostById(id: string):Observable<BlogModel>{
		return this.get(this._path + 'GetPostById',id);
	}
}
