import { Injectable } from '@angular/core';
import { IAuthLogginRequest, IAuthorModel } from '@app/shared/model/auth/auth.model';
import { Observable } from 'rxjs';
import { HttpBaseService } from './http-base.service';

@Injectable({
	providedIn: 'root',
})
export class AuthService extends HttpBaseService {
	private _path = 'auth/'
	public loggin(request: IAuthLogginRequest):Observable<IAuthorModel>{
		return this.post(this._path+ 'login',request);
	}
}
