import { Injectable, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseComponent implements OnDestroy {
  public ngUnSubcribe = new Subject<void>();
  constructor() { }
  ngOnDestroy(): void {
    this.ngUnSubcribe.next();
    this.ngUnSubcribe.complete();
  }
  trackByFn(index: number, item:any): number {
    return item;
  }
}
