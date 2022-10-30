import { Injectable, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class BaseComponent implements OnDestroy {
	protected ngUnSubcribe = new Subject<any>();
	ngOnDestroy(): void {
		this.ngUnSubcribe.complete();
		this.ngUnSubcribe.unsubscribe();
	}
	trackByFn<T>(index:number , item: T){
		return item;
	}
}
