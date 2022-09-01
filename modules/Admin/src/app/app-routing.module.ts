import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotfoundComponent } from './modules/notfound/notfound.component';
import { APP_ROUTE } from './shared/constant/routing.constant';

const routes: Routes = [
  {
    path: APP_ROUTE.AUTH,
    loadChildren: () => import('@modules/auth/auth.module').then((m) => m.AuthModule)
  },
  {
    path: APP_ROUTE.HOME,
    loadChildren: () => import('@modules/home/home.module').then((m) => m.HomeModule)
  },
  {
    path: APP_ROUTE.BLOG,
    loadChildren: () => import('@modules/blog/blog.module').then((m) => m.BlogModule)
  },
  {
    path: APP_ROUTE.FILEMEDIA,
    loadChildren: () => import('@modules/filemedia/filemedia.module').then((m) => m.FilemediaModule)
  },
  {
    path: APP_ROUTE.LANDING,
    loadChildren: () => import('@modules/landing/landing.module').then((m) => m.LandingModule)
  },
  {
    path: APP_ROUTE.SHOP,
    loadChildren: () => import('@modules/shop/shop.module').then((m) => m.ShopModule)
  },
  {
    path: '**',
    component: NotfoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
