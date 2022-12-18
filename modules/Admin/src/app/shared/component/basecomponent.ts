import { Injectable, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Basecomponent implements OnDestroy{
  
  public ngUnsubcribe = new Subject<void>();

  constructor() { 
    
  }

  ngOnDestroy(): void {
      this.ngUnsubcribe.next();
      this.ngUnsubcribe.complete();
  }

  trackByFn(index:number, item:any):number{
    return item;
  }

}
