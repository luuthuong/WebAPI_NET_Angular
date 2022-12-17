import { Injectable, OnDestroy } from "@angular/core";
import { environment } from "environments/environment";
import { Subject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class BaseComponent implements OnDestroy {
    protected ngUnSubcribe = new Subject<void>();
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
