import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { MaterialModule } from '@app/material/material.module';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { BloggerComponent } from './views/blogger/blogger.component';
import { FileMediaComponent } from './views/file-media/file-media.component';
import { LandingpageComponent } from './views/landingpage/landingpage.component';
import { UsersComponent } from './views/users/users.component';

@NgModule({
  declarations: [
    AdminComponent,
    FileMediaComponent,
    UsersComponent,
    LandingpageComponent,
    BloggerComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
    MaterialModule
  ],
  schemas:[
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class AdminModule { }
