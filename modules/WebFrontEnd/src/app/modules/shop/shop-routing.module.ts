import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';

const routes: Routes = [
	{
		path:'',
		component: ShopComponent,
		children: [
			{
				path: '',
				loadChildren: () => import('@modules/home/home.module').then(m => m.HomeModule)
			}
		]
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class ShopRoutingModule {}
