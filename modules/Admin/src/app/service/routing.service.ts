import { Injectable } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Params, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class RoutingService {
	constructor(
		private router: Router,
		private activatedRoute: ActivatedRoute
		) {}

	public navigateTo(path: string[], extras?: NavigationExtras) {
		this.router.navigate(path, extras);
	}

	public getCurrentParams():Observable<Params>{
		return this.activatedRoute.params;
	}
}
