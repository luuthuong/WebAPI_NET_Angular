import { AppInjectorService } from './../../services/app-injector.service';
import { Injectable, OnDestroy } from '@angular/core';
import { environment } from '@env/environment';
import { Subject } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class BaseComponent implements OnDestroy {
	protected ngUnsubscribe = new Subject<void>();
	protected injector;
	constructor(){
		this.injector = AppInjectorService.getInjector();
	}
	ngOnDestroy(): void {
		this.ngUnsubscribe.next();
		this.ngUnsubscribe.complete();
	}
	trackByFn<T>(index:number , item: T){
		return item;
	}

	get environment(){
		return environment;
	}
}
