import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@app/material/material.module';
import { TokenInterceptor } from '@app/shared/core/interceptors/token.interceptor';
import { PipeModule } from '@app/shared/pipe/pipe.module';
import { SharedModule } from '@app/shared/shared.module';
import { CKEditorModule } from 'ng2-ckeditor';
import { BlogDetailComponent } from './blog-detail/blog-detail.component';
import { BlogEditComponent } from './blog-edit/blog-edit.component';
import { BlogOverviewComponent } from './blog-overview/blog-overview.component';
import { BlogRoutingModule } from './blog-routing.module';
import { BlogSearchResultComponent } from './blog-search-result/blog-search-result.component';

@NgModule({
	declarations: [
		BlogOverviewComponent,
		BlogEditComponent,
		BlogDetailComponent,
		BlogSearchResultComponent,
	],
	imports: [
		CommonModule,
		HttpClientModule,
		BlogRoutingModule,
		MaterialModule,
		FormsModule,
		ReactiveFormsModule,
		PipeModule,
		CKEditorModule,
		SharedModule,
	],
	providers: [
		{
			provide: HTTP_INTERCEPTORS,
			useClass: TokenInterceptor,
			multi: true,
		},
	],
})
export class BlogModule {}
