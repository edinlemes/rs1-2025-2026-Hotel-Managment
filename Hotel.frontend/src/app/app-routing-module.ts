import { NgModule } from '@angular/core';
import { RouterModule, Routes, UrlMatchResult, UrlSegment } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/public',
    pathMatch: 'full'
  },
  {
    path: 'public',
    loadChildren: () => import('./modules/public/public-module').then(m => m.PublicModule)
  },

  { matcher: aboutHtmlMatcher, redirectTo: 'about-us', pathMatch: 'full' },
  {matcher: contactHtmlMatcher, redirectTo: 'contact-us', pathMatch: 'full' }
];


function aboutHtmlMatcher(segments: UrlSegment[]): UrlMatchResult | null {
  if (segments.length === 1 && segments[0].path === 'about-us.html') {
    return { consumed: segments };
  }
  return null;
}
function contactHtmlMatcher(segments: UrlSegment[]): UrlMatchResult | null {
  if (segments.length === 1 && segments[0].path === 'contact-us.html') {
    return { consumed: segments };
  }
  return null;
}


@NgModule({
  imports: [RouterModule.forRoot(routes)
],
  exports: [RouterModule]
})
export class AppRoutingModule { }
