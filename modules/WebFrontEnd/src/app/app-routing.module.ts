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
	{
		path:'shop',
		loadChildren: ()=> import('@modules/shop/shop.module').then(m=>m.ShopModule)
	}
];

@NgModule({
	imports: [
		RouterModule.forRoot(routes, {
			useHash:false,
			scrollPositionRestoration: 'enabled',
			anchorScrolling: 'enabled',
			onSameUrlNavigation: 'reload',
			relativeLinkResolution: 'corrected',
			scrollOffset: [0, 64],
		}),
	],
	exports: [RouterModule],
})
export class AppRoutingModule {}
