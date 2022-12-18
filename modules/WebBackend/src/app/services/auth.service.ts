import { Api } from './../shared/constants/Api.constant';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { JwtHelperService } from "@auth0/angular-jwt";
import { CookieStorage } from "app/shared/helpers/cookie-storage";
import { Constants } from "app/shared/constants/constant";
import { ILoginRequest } from "app/shared/models/requests/login-request.model";
import { Observable, tap } from 'rxjs';
import { AuthenticatedUserModel, UserLoginModel } from 'app/shared/models/user.model';
import { IRefreshTokenRequest } from 'app/shared/models/requests/refresh-token-request.model';
import { RefreshTokenModel } from 'app/shared/models/refresh-token.model';
import { IResponseBase } from 'app/shared/models/response.model';

@Injectable()
export class AuthService extends BaseService {
  constructor(
    public override http: HttpClient,
    public jwtHelper: JwtHelperService,
    private cookieHelper: CookieStorage
  ) {
    super(http);
  }
  get refreshToken(): string{
    return this.cookieHelper.get(Constants.JWT_REFRESH_TOKEN);
  }

  set refreshToken(token: string){
    this.cookieHelper.set(Constants.JWT_REFRESH_TOKEN, token);
  }

  get accessToken(): string{
    return this.cookieHelper.get(Constants.JWT_ACCESS_TOKEN);
  }

  set accessToken(token: string){
    this.cookieHelper.set(Constants.JWT_ACCESS_TOKEN, token);
  }

  removeRefreshToken(){
    this.cookieHelper.remove(Constants.JWT_REFRESH_TOKEN);
  }

  removeAccessToken(){
    this.cookieHelper.remove(Constants.JWT_ACCESS_TOKEN);
  }

  removeToken(){
    this.removeAccessToken();
    this.removeRefreshToken();
  }

  get isAuthenticated(){
    try {
      return !this.jwtHelper.isTokenExpired(this.accessToken);
    } catch (_) {
      return false;
    }
  }

  public login(request: ILoginRequest): Observable<UserLoginModel>{
    return this.post(Api.auth.login, request).pipe(tap({
      next:(response : UserLoginModel) =>{
        this.accessToken = response.token;
        this.refreshToken  = response.refreshToken;
      }
    }));
  }

  public refresh(): Observable<IResponseBase<RefreshTokenModel>>{
    const request: IRefreshTokenRequest = {
      refreshToken: this.refreshToken
    };
    return this.post(Api.auth.refreshToken, request).pipe(tap({
      next: (response: IResponseBase<RefreshTokenModel>) =>{
          this.accessToken = response.data.token;
          this.refreshToken =  response.data.refreshToken;        
      }
    }))
  }

  public logout(): Observable<IResponseBase<boolean>>{
    const request: IRefreshTokenRequest ={
      refreshToken: this.refreshToken
    };
    return this.post<IResponseBase<boolean>>(Api.auth.revokeToken, request).pipe(tap({
      finalize: () =>{
        this.removeToken();
      }
    }));
  }

  public getAuthenticatedUser(): Observable<AuthenticatedUserModel>{
    return this.get(Api.auth.userInformation);
  }
}
