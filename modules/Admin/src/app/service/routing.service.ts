import { Injectable } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';

@Injectable({
	providedIn: 'root',
})
export class RoutingService {
	constructor(private route: Router) {}

	public navigateTo(path: string[], extras?: NavigationExtras) {
		this.route.navigate(path, extras);
	}
}
