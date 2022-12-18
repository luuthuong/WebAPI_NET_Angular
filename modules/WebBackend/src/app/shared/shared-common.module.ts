import { MatSnackBarModule } from '@angular/material/snack-bar';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports:[
    MaterialModule
  ]
})
export class SharedCommonModule { }
