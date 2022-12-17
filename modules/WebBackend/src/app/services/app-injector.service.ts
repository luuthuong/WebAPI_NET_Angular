import { Injectable, Injector } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class AppInjectorService {
  static injector: Injector;
  constructor() {}
  static setInjector(injector: Injector) {
    this.injector = injector;
  }
  static getInjector(): Injector {
    return this.injector;
  }
  static getService(type: any){
    const injector = this.getInjector();
    const service = injector.get(type);
    return service;
  }
}
