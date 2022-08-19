import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { BloggerComponent } from './views/blogger/blogger.component';
import { FileMediaComponent } from './views/file-media/file-media.component';
import { LandingpageComponent } from './views/landingpage/landingpage.component';
import { UsersComponent } from './views/users/users.component';
import { LayoutComponent } from './layout/layout.component';
import { MaterialModule } from '@app/material/material.module';



@NgModule({
  declarations: [
    AdminComponent,
    SidebarComponent,
    HeaderComponent,
    FooterComponent,
    FileMediaComponent,
    UsersComponent,
    LandingpageComponent,
    BloggerComponent,
    LayoutComponent
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
