import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PagingParameterModel } from 'app/shared/models/paging-parameter.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  defaultHeader = new HttpHeaders();
	constructor(public http: HttpClient) {}
	protected buildPagingParameters(parameters: PagingParameterModel<any>) {
		const params: any = {};
		if (parameters.pageIndex > -1) {
			params['PageIndex'] = parameters.pageIndex;
		}
		if (parameters.pageSize > -1) {
			params['PageSize'] = parameters.pageSize;
		}
		if (!!parameters.orderBy) {
			if (parameters.orderBy.direction) {
				params['OrderBy.Direction'] = parameters.orderBy.direction;
			}
			if (parameters.orderBy.name) {
				params['OrderBy.Name'] = parameters.orderBy.name;
			}
		}
		if (!!parameters.filterObject) {
			Object.keys(parameters.filterObject).forEach((propName) => {
				let key = 'Filter.' + propName;
				if (!!parameters.filterObject[propName]) {
					params[key] = parameters.filterObject[propName];
				}
			});
		}
		return params;
	}

  protected get<T>(url: string, params: any = {}): Observable<T> {
    return this.http.get<T>(environment.apiUrl + url, { headers: this.defaultHeader, params });
  }

  protected post<T>(url: string, data: any, customHeaders: any = null): Observable<T> {
    let headers: any = this.defaultHeader;
    if (customHeaders) {
      headers = Object.assign(this.defaultHeader, customHeaders);
    }
    return this.http.post<T>(environment.apiUrl + url, data, { headers: headers });
  }

  protected put<T>(url: string, data: any): Observable<T> {
    return this.http.put<T>(environment.apiUrl + url, data, { headers: this.defaultHeader });
  }

  protected delete<T>(url: string, params: any = {}): Observable<T> {
    return this.http.delete<T>(environment.apiUrl + url, { headers: this.defaultHeader, params });
  }
}
