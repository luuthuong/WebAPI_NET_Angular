import { ElementRef, ViewEncapsulation } from '@angular/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { BaseComponent } from '@shared/components/base.component';
import { PARTICLE_CONFIG } from '@shared/constants/particles.config';
import { loadFull } from 'tsparticles';
import { Container, Engine, Particles } from 'tsparticles-engine';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class LandingComponent extends BaseComponent implements OnInit {
  particleConfig = PARTICLE_CONFIG;
  constructor(
    private el: ElementRef
  ) {
    super();
  }

  ngOnInit(): void {
  }

  particlesLoaded(container: Container): void {
    this.el.nativeElement.querySelector("canvas").style.position = "unset"
  }
  async particlesInit(engine: Engine): Promise<void> {
    await loadFull(engine);
  }
}
