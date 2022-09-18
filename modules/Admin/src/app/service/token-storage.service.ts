import { Injectable } from '@angular/core';
import { environment } from '@enviroment/environment';
import { LocalStorageService } from 'angular-2-local-storage';

@Injectable({
	providedIn: 'root',
})
export class TokenStorageService {
	constructor(private _localStorageService: LocalStorageService) {}

	public saveToken(token: string) {
		this._localStorageService.remove(environment.TOKEN_KEY);
		this._localStorageService.add(environment.TOKEN_KEY, token);
	}

	public saveRefreshToken(token: string) {
		this._localStorageService.remove(environment.TOKEN_REFRESH);
		this._localStorageService.add(environment.TOKEN_REFRESH, token);
	}

	public getToken(): string {
		return this._localStorageService.get(environment.TOKEN_KEY);
	}

	public getRefreshToken(): string {
		return this._localStorageService.get(environment.TOKEN_REFRESH);
	}

	public saveUser(user: any) {
		this._localStorageService.add(
			environment.TOKEN_USER,
			JSON.stringify(user)
		);
	}
}
