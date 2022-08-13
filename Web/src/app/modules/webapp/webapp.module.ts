import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WebappComponent } from './webapp.component';
import { WebappRoutingModule } from './webapp-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    WebappComponent
  ],
  imports: [
    CommonModule,
    WebappRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WebappModule { }
