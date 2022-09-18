import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotfoundComponent } from './modules/notfound/notfound.component';
import { APP_ROUTE } from './shared/constant/routing.constant';
import { AuthGuard } from './shared/guard/auth.guard';

const routes: Routes = [
	{
		path: APP_ROUTE.AUTH,
		loadChildren: () =>
			import('@modules/auth/auth.module').then((m) => m.AuthModule),
	},
	{
		path: '',
		loadChildren:()=>import('@modules/admin.module').then(m=>m.AdminModule),
		canActivate: [AuthGuard]
	}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
