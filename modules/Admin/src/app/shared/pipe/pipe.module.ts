import { NgModule } from '@angular/core';
import { AppDatePipe } from './appdate.pipe';
import { SafehtmlPipe } from './safehtml.pipe';

@NgModule({
  declarations: [
    SafehtmlPipe,
    AppDatePipe
  ],
  exports:[
    SafehtmlPipe,
    AppDatePipe
  ]
})
export class PipeModule { }
