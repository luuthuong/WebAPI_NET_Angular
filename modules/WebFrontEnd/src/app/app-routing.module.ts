import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
	{
		path: '',
		loadChildren: () =>
			import('@modules/landing/landing.module').then(
				(m) => m.LandingModule
			),
	},
];

@NgModule({
	imports: [
		RouterModule.forRoot(routes, {
			scrollPositionRestoration: 'enabled',
			anchorScrolling: 'enabled',
			onSameUrlNavigation: 'reload',
			relativeLinkResolution: 'legacy',
			scrollOffset: [0, 64],
		}),
	],
	exports: [RouterModule],
})
export class AppRoutingModule {}
