import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@app/material/material.module';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { BloggerComponent } from './views/blogger/blogger.component';
import { FileMediaComponent } from './views/file-media/file-media.component';
import { LandingpageComponent } from './views/landingpage/landingpage.component';
import { UsersComponent } from './views/users/users.component';
import { BlogDetailComponent } from './views/blogger/blog-detail/blog-detail.component';
import { BlogFilterComponent } from './views/blogger/blog-filter/blog-filter.component';

@NgModule({
  declarations: [
    AdminComponent,
    FileMediaComponent,
    UsersComponent,
    LandingpageComponent,
    BloggerComponent,
    BlogDetailComponent,
    BlogFilterComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
    MaterialModule,
    AngularEditorModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  schemas:[
    CUSTOM_ELEMENTS_SCHEMA
  ],
  bootstrap:[
  ]
})
export class AdminModule { }
