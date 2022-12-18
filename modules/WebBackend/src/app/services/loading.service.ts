import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { AppInjectorService } from './app-injector.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  constructor(
    private spinner: NgxSpinnerService
  ) { }
  
  setStateLoading(state: boolean){
    state ? this.spinner.show() : this.spinner.hide();      
  }
}
