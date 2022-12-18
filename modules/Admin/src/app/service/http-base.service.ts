import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@enviroment/environment';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class HttpBaseService {
	headers = new HttpHeaders();
	constructor(private http: HttpClient) {}

	protected get(url: string, params: any = {}): Observable<any> {
		return this.http.get(environment.baseURL + url, {
			headers: this.headers,
			params,
		});
	}

	protected post(url: string, data: any): Observable<any> {
		return this.http.post(environment.baseURL + url, data, {
			headers: this.headers,
		});
	}

	protected put(url: string, data: any): Observable<any> {
		return this.http.put(environment.baseURL + url, data, {
			headers: this.headers,
		});
	}

	protected delete(url: string, params: any = {}): Observable<any> {
		return this.http.delete(environment.baseURL + url, {
			headers: this.headers,
			params,
		});
	}
}
