import { Injectable } from '@angular/core';
import {
	ActivatedRouteSnapshot,
	CanActivate,
	Router,
	RouterStateSnapshot,
	UrlTree,
} from '@angular/router';
import { AuthService } from '@app/service/auth.service';
import { TokenStorageService } from '@app/service/token-storage.service';
import { APP_ROUTE, AUTH_ROUTE } from '@app/shared/constant/routing.constant';
import { Observable, take } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class AuthGuard implements CanActivate {
	constructor(
		private authService: AuthService,
		private router: Router,
		private tokenStorageService: TokenStorageService
	){

	}
	canActivate(
		route: ActivatedRouteSnapshot,
		state: RouterStateSnapshot
	):
		| Observable<boolean | UrlTree>
		| Promise<boolean | UrlTree>
		| boolean
		| UrlTree {
		this.authService.checkLogin().pipe(take(1)).subscribe({
			error:()=>{
				this.tokenStorageService.clearAllToken();
				this.router.navigate([APP_ROUTE.AUTH, AUTH_ROUTE.LOGIN]);
			}
		});
		return true;
	}
}
