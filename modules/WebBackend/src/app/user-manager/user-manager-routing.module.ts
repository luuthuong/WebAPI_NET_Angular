import { RouterModule, Routes } from '@angular/router';
import { UserManagerComponent } from './user-manager/user-manager.component';
import { NgModule } from '@angular/core';
import { CreateEditUserComponent } from './create-edit-user/create-edit-user.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
const routes: Routes = [
    {
        path: '',
        component: UserManagerComponent
    },
    {
        path: 'profile',
        component: UserProfileComponent
    },
    {
        path: 'create',
        component: CreateEditUserComponent
    },
    {
        path: 'edit/:id',
        component: CreateEditUserComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes, {
            useHash: true
        })
    ],
    exports: [
        RouterModule
    ],
})
export class UsermanagerRoutingModule { }
