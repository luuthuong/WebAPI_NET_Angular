import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { RoleGuard } from './shared/guards/role.guard';
import { Constants } from './shared/constants/constant';
import { RoleTypeEnum } from './shared/enums/role-type.enum';

const routes: Routes =[
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
    canActivate:[AuthGuard, RoleGuard]
  }, 
  {
    path: '',
    component: AdminLayoutComponent,
    children: [{
      path: '',
      loadChildren: () => import('./layouts/admin-layout/admin-layout.module').then(m => m.AdminLayoutModule)
    }],
    canActivate:[AuthGuard, RoleGuard],
    data:{
      expectedRole: RoleTypeEnum.Admin
    }
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then( m => m.AuthModule)
  }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes,{
       useHash: true
    })
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
