import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicRoutingModule } from './public-routing-module';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { AboutUs } from './about-us/about-us';

@NgModule({
  declarations: [
    AboutUs
  ],
  imports: [
    LandingPageComponent,
    CommonModule,
    PublicRoutingModule
  ]
})
export class PublicModule { }
