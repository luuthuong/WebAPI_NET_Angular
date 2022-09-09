import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@enviroment/environment';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class HttpBaseService {
	private _headers = new HttpHeaders();
	constructor(private _http: HttpClient) {}

	public get<T>(url: string, params: any = {}): Observable<T> {
		return this._http.get(environment.appSetting?.apiURL + url, {
			headers: this._headers,
			params: params,
		}) as Observable<T>;
	}

	public post<T>(url: string, payload: any): Observable<T> {
		return this._http.post(environment.appSetting?.apiURL + url, payload, {
			headers: this._headers,
		}) as Observable<T>;
	}

	public put<T>(url: string, payload: any): Observable<T> {
		return this._http.put(environment.appSetting?.apiURL + url, payload, {
			headers: this._headers,
		}) as Observable<T>;
	}

	public delete(url: string, params: any = {}): Observable<any> {
		return this._http.delete(environment.appSetting?.apiURL + url, {
			headers: this._headers,
			params,
		});
	}
}
