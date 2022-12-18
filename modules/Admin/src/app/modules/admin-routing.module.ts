import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { APP_ROUTE } from '@app/shared/constant/routing.constant';
import { AdminComponent } from './admin.component';
import { NotfoundComponent } from './notfound/notfound.component';

const routes: Routes = [
	{
		path: '',
		component:AdminComponent,
		children:[
			{
				path: APP_ROUTE.HOME,
				loadChildren: () =>
					import('@modules/home/home.module').then((m) => m.HomeModule),
			},
			{
				path: APP_ROUTE.BLOG,
				loadChildren: () =>
					import('@modules/blog/blog.module').then((m) => m.BlogModule),
			},
			{
				path: APP_ROUTE.FILEMEDIA,
				loadChildren: () =>
					import('@modules/filemedia/filemedia.module').then(
						(m) => m.FilemediaModule
					),
			},
			{
				path: APP_ROUTE.LANDING,
				loadChildren: () =>
					import('@modules/landing/landing.module').then(
						(m) => m.LandingModule
					),
			},
			{
				path: APP_ROUTE.SHOP,
				loadChildren: () =>
					import('@modules/shop/shop.module').then((m) => m.ShopModule),
			},
			{
				path: '**',
				component: NotfoundComponent,
			},
		]
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class AdminRoutingModule {}
