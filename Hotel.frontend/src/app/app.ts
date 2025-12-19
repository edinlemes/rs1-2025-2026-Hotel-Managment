import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: false,
  templateUrl: './app.html',
  // @ts-expect-error Angular 21 type definitions have conflicting styleUrls types
  styleUrls: ['./app.scss']
})
export class App {
  protected readonly title = signal('Hotel.Frontend');
}
