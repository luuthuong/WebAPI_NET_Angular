import { Injectable, Injector } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { finalize, Observable } from 'rxjs';
import { AppInjectorService } from 'app/services/app-injector.service';
import { LoadingService } from 'app/services/loading.service';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  private isIgnoreLoadingState: boolean = false;
  ignoreHttpRequest : string[] = [];
  countActiveRequest: number = 0;
  protected injector: Injector;
  protected loadingSerive: LoadingService;
  constructor(){
    this.injector = AppInjectorService.getInjector();
    this.loadingSerive = this.injector.get(LoadingService);
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const serviceRequest = request.url.substring(request.url.lastIndexOf('/') + 1);
    this.ignoreHttpRequest.every(e =>{
      if(e === serviceRequest){
        this.isIgnoreLoadingState = true;
        return false;
      }
      return true;
    });
    console.log('http request loading ...');
    this.countActiveRequest === 0 && this.loadingSerive.setStateLoading(!this.isIgnoreLoadingState);
    this.countActiveRequest += 1;
    return next.handle(request).pipe(
      finalize(() => {
        this.countActiveRequest -= 1;
        this.countActiveRequest === 0 && this.loadingSerive.setStateLoading(false);
      })
    );
  }
}
