import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { BLOG_ROUTE } from '@app/shared/constant/routing.constant';
import { BlogOverviewComponent } from './blog-overview/blog-overview.component';
import { BlogDetailComponent } from './blog-detail/blog-detail.component';
import { BlogEditComponent } from './blog-edit/blog-edit.component';
import { BlogSearchResultComponent } from './blog-search-result/blog-search-result.component';

const routes: Routes = [
  {
    path: BLOG_ROUTE.OVERVIEW,
    component: BlogOverviewComponent,
  },
  {
    path: BLOG_ROUTE.EDIT,
    component: BlogEditComponent,
  },
  {
    path: BLOG_ROUTE.CREATE,
    component: BlogEditComponent,
  },
  {
    path: BLOG_ROUTE.DETAIL,
    component: BlogDetailComponent,
  },
  {
    path: BLOG_ROUTE.SEARCH,
    component: BlogSearchResultComponent,
  },
  {
    path: '',
    redirectTo: BLOG_ROUTE.OVERVIEW,
    pathMatch: 'full',
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BlogRoutingModule {}
