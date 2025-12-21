import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [RouterLink],
  template: `
    <footer class="mt-auto bg-[#2c3e50] px-4 py-6 text-center text-white sm:px-6 lg:px-10" role="contentinfo">
      <div class="mx-auto flex max-w-6xl flex-col items-center gap-3 sm:flex-row sm:justify-between">
        <p class="text-sm opacity-90">&copy; 2025 Hotel Management System. Sva prava zadržana.</p>
        <div class="flex items-center gap-4 text-xs opacity-90">
          <a
            routerLink="/public/privacy"
            class="transition hover:opacity-100 focus:outline-none focus-visible:rounded-sm focus-visible:ring-2 focus-visible:ring-white/60"
            >Privatnost</a
          >
          <span class="hidden h-4 w-px bg-white/40 sm:block" aria-hidden="true"></span>
          <a
            routerLink="/public/terms"
            class="transition hover:opacity-100 focus:outline-none focus-visible:rounded-sm focus-visible:ring-2 focus-visible:ring-white/60"
            >Uslovi</a
          >
        </div>
      </div>
    </footer>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FooterComponent {}
