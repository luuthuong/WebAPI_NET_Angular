import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from '../landing/landing.component';
import { AdminRoute } from './admin-model/admin-constants';
import { AdminComponent } from './admin.component';
import { BloggerComponent } from './views/blogger/blogger.component';
import { FileMediaComponent } from './views/file-media/file-media.component';
import { HomeComponent } from './views/home/home.component';
import { UsersComponent } from './views/users/users.component';

const routes: Routes = [
	{
		path: '',
		component: AdminComponent,
		children: [
			{
				path: AdminRoute.HOME,
				component: HomeComponent,
			},
			{
				path: AdminRoute.BLOG,
				component: BloggerComponent,
			},
      {
        path: AdminRoute.LANDING,
        component: LandingComponent
      },
      {
        path: AdminRoute.FILEMEDIA,
        component: FileMediaComponent
      },
      {
        path: AdminRoute.USER,
        component: UsersComponent
      }
		],
	},
];

@NgModule({
	declarations: [],
	imports: [CommonModule, RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class AdminRoutingModule {}
