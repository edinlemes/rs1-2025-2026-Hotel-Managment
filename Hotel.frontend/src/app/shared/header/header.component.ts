import { ChangeDetectionStrategy, Component } from '@angular/core';
import { NgFor } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';

interface NavLink {
  label: string;
  path: string;
  exact?: boolean;
}

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NgFor],
  template: `
    <header
      class="sticky top-0 z-30 bg-white/90 shadow-sm backdrop-blur supports-[backdrop-filter]:bg-white/80"
      role="banner"
    >
      <div class="mx-auto flex max-w-6xl items-center justify-between px-4 py-3 sm:px-6 lg:px-10">
        <a
          routerLink="/public"
          class="flex items-center gap-2 text-[var(--color-text)] focus:outline-none focus-visible:rounded-md focus-visible:ring-2 focus-visible:ring-[var(--color-brand)]/50"
          aria-label="Hotel Management System home"
        >
          <span class="flex h-9 w-9 items-center justify-center rounded-xl bg-[var(--color-brand-2)] text-lg text-white">🏨</span>
          <span class="text-base font-semibold">Hotel Management System</span>
        </a>

        <nav class="hidden items-center gap-5 text-sm text-[var(--color-text)] sm:flex" aria-label="Primary">
          <a
            *ngFor="let link of navLinks"
            [routerLink]="link.path"
            [routerLinkActive]="'text-[var(--color-brand-2)] font-semibold'"
            [routerLinkActiveOptions]="{ exact: !!link.exact }"
            class="rounded-md px-2 py-1 transition hover:text-[var(--color-brand-2)] focus:outline-none focus-visible:ring-2 focus-visible:ring-[var(--color-brand-2)]/50"
          >
            {{ link.label }}
          </a>
        </nav>

        <div class="hidden sm:inline-flex">
          <a
            routerLink="/auth/register"
            class="inline-flex items-center rounded-full bg-[var(--color-brand-2)] px-4 py-2 text-sm font-semibold text-white shadow-sm transition hover:bg-[var(--color-brand-2-dark)] focus:outline-none focus-visible:ring-2 focus-visible:ring-[var(--color-brand-2)]/60"
          >
            Login
          </a>
        </div>
      </div>
    </header>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HeaderComponent {
  readonly navLinks: NavLink[] = [
    { label: 'Home', path: '/public', exact: true },
    { label: 'Hoteli', path: '/public/hotels' },
    { label: 'O nama', path: '/public/about-us' },
    { label: 'Kontakt', path: '/public/contact-us' },
  ];
}
