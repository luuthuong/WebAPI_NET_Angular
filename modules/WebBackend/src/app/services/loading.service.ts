import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  private getLoading$ = new Subject<boolean>();
  constructor() { }
  
  setStateLoading(state: boolean){
    this.getLoading$.next(state);
  }

  getStateLoading(){
    return this.getLoading$.asObservable();
  }
}
