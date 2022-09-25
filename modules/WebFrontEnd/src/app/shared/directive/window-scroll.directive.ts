import { Location } from '@angular/common';
import { Directive, HostListener } from '@angular/core';
import { Router } from '@angular/router';

@Directive({
  selector: '[appWindowScroll]'
})
export class WindowScrollDirective {

  constructor(
    private router: Router,
    private location: Location
  ) { }
  @HostListener('window:scroll',['$event'])
  onWindowScroll($event:any){
    console.log(window.scrollY,)
  }

}
