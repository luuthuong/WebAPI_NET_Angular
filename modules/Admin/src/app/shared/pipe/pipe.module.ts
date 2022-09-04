import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SafehtmlPipe } from './safehtml.pipe';

@NgModule({
  declarations: [
    SafehtmlPipe
  ],
  exports:[
    SafehtmlPipe
  ]
})
export class PipeModule { }
