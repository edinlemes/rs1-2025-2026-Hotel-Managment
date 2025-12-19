import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicRoutingModule } from './public-routing-module';
import { LandingPageComponent } from './landing-page/landing-page.component';

@NgModule({
  declarations: [],
  imports: [
    LandingPageComponent,
    CommonModule,
    PublicRoutingModule
  ]
})
export class PublicModule { }
