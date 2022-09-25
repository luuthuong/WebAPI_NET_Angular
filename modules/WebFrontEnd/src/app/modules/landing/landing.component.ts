import { Location } from '@angular/common';
import { ChangeDetectionStrategy, ElementRef, ViewEncapsulation } from '@angular/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { BaseComponent } from '@shared/components/base.component';
import { PARTICLE_CONFIG } from '@shared/constants/particles.config';
import { fromEvent, takeUntil } from 'rxjs';
import { loadFull } from 'tsparticles';
import { Container, Engine, Particles } from 'tsparticles-engine';

interface INavigateToolbar {
  display: string;
  fragment: string;
}

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class LandingComponent extends BaseComponent implements OnInit {
  public particleConfig = PARTICLE_CONFIG;
  public subTitleArr = 'Smart Investment'.split('');
  public navigateToolbar: INavigateToolbar[] = [
    {
      display: 'Trang chủ',
      fragment: 'home',
    },
    {
      display: 'Story',
      fragment: 'story',
    },
    {
      display: 'Hồ sơ',
      fragment: 'portfolio',
    },
    {
      display: 'Bài viết',
      fragment: 'blog',
    },
    {
      display: 'Cửa hàng',
      fragment: 'shop',
    },
    {
      display: 'Liên hệ',
      fragment: 'contact',
    },
  ];
  public isChangeToolbar: boolean = false;
  public currentFragment: string = "";
  constructor(
    private el: ElementRef,
    private router: Router,
    private location: Location
    ) {
    super();
    this.subTitleArr = this.subTitleArr.map(
      (x) => (x = x === ' ' ? '&nbsp;' : x)
    );

    fromEvent(window, 'scroll')
      .pipe(takeUntil(this.ngUnSubcribe))
      .subscribe((e: Event) => {
        const positionY = window.scrollY;
        const homeEl = this.el.nativeElement.querySelector("#home") as Element;
        this.isChangeToolbar = (positionY > homeEl.clientHeight - 65) && !!this.router.parseUrl(this.router.url).fragment;
      });

      this.router.events
      .pipe(takeUntil(this.ngUnSubcribe))
      .subscribe(result=>{
        if(result instanceof NavigationEnd){
          this.currentFragment = this.router.parseUrl(result.url).fragment || '';
        }
      })
  }

  ngOnInit(): void {}

  particlesLoaded(container: Container): void {
    this.el.nativeElement.querySelector('canvas').style.position = 'absolute';
    this.el.nativeElement.querySelector('canvas').style.zIndex = '0';
  }

  async particlesInit(engine: Engine): Promise<void> {
    await loadFull(engine);
  }
  getYPosition(e:any): number {
    return (e.target as Element).scrollTop;
 }
}
