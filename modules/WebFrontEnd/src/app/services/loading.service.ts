import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  private isLoading$ = new Subject<boolean>();
  constructor() { }

  setStateLoading(state: boolean){
    this.isLoading$.next(state);
  }

  getStateLoading(): Observable<boolean>{
    return this.isLoading$.asObservable();
  }
}
