import { Injectable, Injector } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, finalize } from 'rxjs';
import { LoadingService } from 'app/services/loading.service';
import { AppInjectorService } from 'app/services/app-injector.service';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  protected injector: Injector;
  protected loadingService: LoadingService;
  constructor() {
    this.injector = AppInjectorService.getInjector();
    this.loadingService = this.injector.get(LoadingService);
  }
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.loadingService.setStateLoading(true);
    return next.handle(request).pipe(finalize(()=>{
      this.loadingService.setStateLoading(false);
    }));
  }
}
