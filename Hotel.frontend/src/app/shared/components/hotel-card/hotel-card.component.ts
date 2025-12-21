import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { Hotel } from '../../models/hotel.model';

@Component({
  selector: 'app-hotel-card',
  standalone: true,
  imports: [],
  template: `
    <article
      class="group flex h-full flex-col overflow-hidden rounded-2xl border border-gray-200 bg-white shadow-sm transition-all duration-300 hover:shadow-lg hover:shadow-[var(--color-brand-2)]/10"
    >
      <!-- Hotel Header -->
      <div class="bg-gradient-to-br from-[var(--color-brand-2)] to-[var(--color-brand-2-dark)] p-5 text-white">
        <h3 class="text-xl font-bold tracking-tight">{{ hotel.name }}</h3>
        <p class="mt-1 text-sm opacity-90">{{ hotel.hotelCode }}</p>
      </div>

      <!-- Hotel Details -->
      <div class="flex flex-1 flex-col gap-3 p-5">
        <!-- Address -->
        <div class="flex items-start gap-2">
          <svg
            class="mt-0.5 h-5 w-5 flex-shrink-0 text-[var(--color-brand-2)]"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
            aria-hidden="true"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z"
            />
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M15 11a3 3 0 11-6 0 3 3 0 016 0z"
            />
          </svg>
          <div class="min-w-0 flex-1">
            <p class="text-sm text-gray-700">{{ hotel.address }}</p>
            <p class="text-sm text-gray-600">
              {{ hotel.city }}, {{ hotel.state }} {{ hotel.zipCode }}
            </p>
          </div>
        </div>

        <!-- Phone -->
        <div class="flex items-center gap-2">
          <svg
            class="h-5 w-5 flex-shrink-0 text-[var(--color-brand-2)]"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
            aria-hidden="true"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M3 5a2 2 0 012-2h3.28a1 1 0 01.948.684l1.498 4.493a1 1 0 01-.502 1.21l-2.257 1.13a11.042 11.042 0 005.516 5.516l1.13-2.257a1 1 0 011.21-.502l4.493 1.498a1 1 0 01.684.949V19a2 2 0 01-2 2h-1C9.716 21 3 14.284 3 6V5z"
            />
          </svg>
          <a
            [href]="'tel:' + hotel.phoneNumber"
            class="text-sm text-gray-700 transition hover:text-[var(--color-brand-2)]"
          >
            {{ hotel.phoneNumber }}
          </a>
        </div>

        <!-- Email -->
        <div class="flex items-center gap-2">
          <svg
            class="h-5 w-5 flex-shrink-0 text-[var(--color-brand-2)]"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
            aria-hidden="true"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M3 8l7.89 5.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"
            />
          </svg>
          <a
            [href]="'mailto:' + hotel.companyMailAddress"
            class="truncate text-sm text-gray-700 transition hover:text-[var(--color-brand-2)]"
          >
            {{ hotel.companyMailAddress }}
          </a>
        </div>

        <!-- Website -->
        <div class="flex items-center gap-2">
          <svg
            class="h-5 w-5 flex-shrink-0 text-[var(--color-brand-2)]"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
            aria-hidden="true"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M21 12a9 9 0 01-9 9m9-9a9 9 0 00-9-9m9 9H3m9 9a9 9 0 01-9-9m9 9c1.657 0 3-4.03 3-9s-1.343-9-3-9m0 18c-1.657 0-3-4.03-3-9s1.343-9 3-9m-9 9a9 9 0 019-9"
            />
          </svg>
          <a
            [href]="hotel.websiteAddress"
            target="_blank"
            rel="noopener noreferrer"
            class="truncate text-sm text-[var(--color-brand-2)] transition hover:text-[var(--color-brand-2-dark)] hover:underline"
          >
            {{ formatWebsite(hotel.websiteAddress) }}
          </a>
        </div>
      </div>

      <!-- Card Footer -->
      <div class="border-t border-gray-100 bg-gray-50 px-5 py-3">
        <button
          type="button"
          class="w-full rounded-lg bg-[var(--color-brand-2)] px-4 py-2 text-sm font-semibold text-white transition hover:bg-[var(--color-brand-2-dark)] focus:outline-none focus-visible:ring-2 focus-visible:ring-[var(--color-brand-2)]/60"
        >
          View Details
        </button>
      </div>
    </article>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HotelCardComponent {
  @Input({ required: true }) hotel!: Hotel;

  formatWebsite(url: string): string {
    return url.replace(/^https?:\/\//, '').replace(/\/$/, '');
  }
}
