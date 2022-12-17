import { Injectable, Injector } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppInjectorService {
  public static injector : Injector;
  constructor() { }

  static setInjector(injector: Injector){
    AppInjectorService.injector = injector;
  }

  static getInjector(): Injector{
    return AppInjectorService.injector;
  }
  static getService(type: any){
    const injector = AppInjectorService.getInjector();
    const service = injector.get(type);
    return service;
  }
}
