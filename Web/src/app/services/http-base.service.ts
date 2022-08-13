import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class HttpBaseService {

  private headers = new HttpHeaders();
  constructor(
    private http : HttpClient
  ) { }

  public get(url:string , params:any={}):Observable<any>{
    return this.http.get(environment.appSetting.apiURL + url,{
      headers: this.headers,
      params: params
    })
  }

  public post<T>(url:string, data:T):Observable<any>{
    return this.http.post(environment.appSetting.apiURL + url,data,{
      headers:this.headers
    });
  }

  public put<T>(url:string, data:T):Observable<any>{
    return this.http.put(environment.appSetting.apiURL+ url, data,{
      headers: this.headers
    })
  }

  public delete(url:string, params:any):Observable<any>{
    return this.http.delete(environment.appSetting.apiURL + url, {
      headers:this.headers,
      params:params
    })
  }
}
