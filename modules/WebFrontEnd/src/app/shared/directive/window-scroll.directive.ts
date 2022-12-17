import { Location } from '@angular/common';
import { Directive, HostListener, ElementRef } from '@angular/core';
import { Router } from '@angular/router';

@Directive({
	selector: '[appWindowScroll]',
})
export class WindowScrollDirective {
	constructor(
		private router: Router,
		private location: Location,
		private el : ElementRef
		) {}
	@HostListener('window:scroll', ['$event'])
	onWindowScroll($event: any) {
		const element = this.el.nativeElement as Element;
	}
}
