import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { JWTHelper } from '../helpers/jwt-helper';
import { RoleTypeEnum } from '../enums/role-type.enum';
import { ToastService } from 'app/services/toast.service';
import { AuthService } from 'app/services/auth.service';
import { Pages } from '../constants/page.constant';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router
  ){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const expectedRole =RoleTypeEnum[route.data['expectedRole']] ;
    const tokenPayload = JWTHelper.parseJwt;
    const isMatchRole = expectedRole === tokenPayload.Role;
    if(!isMatchRole || !this.authService.isAuthenticated){
      ToastService.error("Người dùng không có đủ quyền truy cập!");
      this.authService.removeToken();
      this.router.navigate([Pages.auth, Pages.login], {
        queryParams: {
          returnUrl: route.url
        }
      });
      return false;
    }
    return true;
  }
  
}
