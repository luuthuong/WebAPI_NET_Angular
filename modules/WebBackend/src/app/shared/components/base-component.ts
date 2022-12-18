import { Injectable, OnDestroy } from "@angular/core";
import { Router } from "@angular/router";
import { AppInjectorService } from "app/services/app-injector.service";
import { environment } from "environments/environment";
import { Subject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class BaseComponent implements OnDestroy {
    protected ngUnSubcribe = new Subject<void>();
    protected router: Router;
    constructor(){
        this.router = AppInjectorService.getService(Router);
    }
    ngOnDestroy(): void {
        this.ngUnSubcribe.next();
        this.ngUnSubcribe.complete();
    }
    trackByFn<T>(index: number, item: T){
        return item;
    }

    get environment(){
        return environment;
    }
}
