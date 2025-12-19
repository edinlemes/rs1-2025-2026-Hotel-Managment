import { Component } from '@angular/core';

@Component({
  selector: 'app-landing-page',
  standalone: false,
  templateUrl: './landing-page.component.html',
  // @ts-expect-error Angular 21 type definitions have conflicting styleUrls types
  styleUrls: ['./landing-page.component.scss']
})
export class LandingPageComponent {}
