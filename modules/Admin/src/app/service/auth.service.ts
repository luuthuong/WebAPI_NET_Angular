import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
	IAuthLogginRequest,
	IAuthorModel
} from '@app/shared/model/auth/auth.model';
import { Observable, take } from 'rxjs';
import { HttpBaseService } from './http-base.service';
import { TokenStorageService } from './token-storage.service';

@Injectable({
	providedIn: 'root',
})
export class AuthService extends HttpBaseService {
	private _path = 'auth/';
	constructor(
		private _http: HttpClient,
		private _tokenService: TokenStorageService
		) {
		super(_http);
	}
	public loggin(request: IAuthLogginRequest): Observable<IAuthorModel> {
		return this.post(this._path + 'login', request);
	}

	public checkLogin():Observable<boolean> {
		return this.get(this._path+ 'CheckExpiredToken');
	}

	public logOut(){
		this._tokenService.clearAllToken();
		window.location.reload();
	}
}
