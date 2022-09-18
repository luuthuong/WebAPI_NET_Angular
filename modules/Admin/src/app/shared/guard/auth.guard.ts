import { Injectable } from '@angular/core';
import {
	ActivatedRouteSnapshot,
	CanActivate,
	Router,
	RouterStateSnapshot,
	UrlTree,
} from '@angular/router';
import { AuthService } from '@app/service/auth.service';
import { Observable } from 'rxjs';
import { APP_ROUTE, AUTH_ROUTE } from '../constant/routing.constant';

@Injectable({
	providedIn: 'root',
})
export class AuthGuard implements CanActivate {
	constructor(private authService: AuthService, private router: Router) {}

	canActivate(
		route: ActivatedRouteSnapshot,
		state: RouterStateSnapshot
	):
		| Observable<boolean | UrlTree>
		| Promise<boolean | UrlTree>
		| boolean
		| UrlTree {
		const canLogin = this.authService.checkLogin();
		if (!canLogin) this.router.navigate([APP_ROUTE.AUTH, AUTH_ROUTE.LOGIN]);
		return canLogin;
	}
}
