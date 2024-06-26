import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LandingRoutingModule } from './landing-routing.module';
import { LandingComponent } from './landing.component';
import { SharedCommonModule } from '@shared/shared-common.module';

@NgModule({
	declarations: [LandingComponent],
	imports: [CommonModule, LandingRoutingModule, SharedCommonModule],
})
export class LandingModule {}
