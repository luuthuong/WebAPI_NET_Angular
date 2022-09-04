import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlogOverviewComponent } from './blog-overview/blog-overview.component';
import { BlogEditComponent } from './blog-edit/blog-edit.component';
import { BlogDetailComponent } from './blog-detail/blog-detail.component';
import { BlogSearchResultComponent } from './blog-search-result/blog-search-result.component';
import { BlogRoutingModule } from './blog-routing.module';
import { MaterialModule } from '@app/material/material.module';
import { NgxEditorModule } from 'ngx-editor';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { PipeModule } from '@app/shared/pipe/pipe.module';

@NgModule({
  declarations: [
    BlogOverviewComponent,
    BlogEditComponent,
    BlogDetailComponent,
    BlogSearchResultComponent,
  ],
  imports: [
    CommonModule,
    BlogRoutingModule,
    MaterialModule,
    NgxEditorModule.forChild({
      locals:{
        bold:'Bold',
        italic:'Italic',
        code:'Code',
        underline:'Underline'
      }
    }),
    FormsModule,
    ReactiveFormsModule,
    PipeModule
  ]
})

export class BlogModule { }
