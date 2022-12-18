import { Injectable } from '@angular/core';
import { HttpBaseService } from '../http-base.service';
import { CreateNewPostRequest } from '@app/shared/model/blog/createNewPost.model';
import { BlogModel } from '@app/shared/model/blog/blogModel';
import { Observable } from 'rxjs';
import { IDeletePostModelRequest } from '@app/shared/model/blog/deletePostRequest.model';
import { IUpdatePostModelRequest } from '@app/shared/model/blog/updatePostRequest.model';
@Injectable({
	providedIn: 'root',
})
export class BlogService extends HttpBaseService {
	private _path = 'BlogPost/'
	public createNewPost(request: CreateNewPostRequest): Observable<any>{
		return this.post(this._path + 'Create',request);
	}

	public getAllPost():Observable<BlogModel[]>{
		return this.get(this._path + 'getAllPost');
	}

	public getPostById(id: string):Observable<BlogModel>{
		return this.get(this._path + 'GetPostById',{
			id:id
		});
	}

	public deletePost(request: IDeletePostModelRequest){
		return this.delete(this._path,request);
	}

	public updatePostById(id: string, request:IUpdatePostModelRequest){
		return this.put(this._path+`?id=${id}`,request);
	}
}
