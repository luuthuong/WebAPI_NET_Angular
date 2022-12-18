import { Injectable, Injector } from "@angular/core";

export class AppInjectorService {
  private static injector: Injector;
  static setInjector(injector: Injector) {
    AppInjectorService.injector = injector;
  }
  static getInjector(): Injector {
    return AppInjectorService.injector;
  }
  static getService<T>(type: any ): T{
    const injector = AppInjectorService.getInjector();
    const service: T = injector.get(type) as T;
    return service;
  }
}
