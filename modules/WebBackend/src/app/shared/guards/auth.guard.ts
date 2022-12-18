import { ToastService } from 'app/services/toast.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AuthService } from 'app/services/auth.service';
import { Observable } from 'rxjs';
import { Pages } from '../constants/page.constant';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
  ){

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if(!this.authService.isAuthenticated){
      ToastService.error('Người dùng chưa xác thực. Vui lòng đăng nhập lại!')
      this.authService.removeToken();
      this.router.navigate([Pages.auth,Pages.login], {
        queryParams: {
          returnUrl: state.url
        }
      });
      return false;
    }
    return true;
  }
  
}
