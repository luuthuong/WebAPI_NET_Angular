import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateEditUserComponent } from './create-edit-user/create-edit-user.component';
import { UserManagerComponent } from './user-manager/user-manager.component';
import { UsermanagerRoutingModule } from './user-manager-routing.module';
import { SharedCommonModule } from 'app/shared/shared-common.module';
import { UserProfileComponent } from './user-profile/user-profile.component';

@NgModule({
  declarations: [
    CreateEditUserComponent,
    UserManagerComponent,
    UserProfileComponent
  ],
  imports: [
    CommonModule,
    UsermanagerRoutingModule,
    SharedCommonModule
  ]
})
export class UserManagerModule { }
