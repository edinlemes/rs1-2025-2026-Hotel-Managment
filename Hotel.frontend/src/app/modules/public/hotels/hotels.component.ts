import { ChangeDetectionStrategy, Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HotelsService } from '../../../core/services/hotels.service';
import { Hotel, HotelsFilterParams } from '../../../shared/models/hotel.model';
import { HotelCardComponent } from '../../../shared/components/hotel-card/hotel-card.component';

@Component({
  selector: 'app-hotels',
  standalone: true,
  imports: [FormsModule, HotelCardComponent],
  templateUrl: './hotels.component.html',
  styleUrl: './hotels.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HotelsComponent implements OnInit {
  // State signals
  hotels = signal<Hotel[]>([]);
  isLoading = signal<boolean>(false);
  errorMessage = signal<string>('');

  // Pagination state
  currentPage = signal<number>(1);
  pageSize = signal<number>(9);
  totalPages = signal<number>(1);
  totalCount = signal<number>(0);

  // Filter state
  searchTerm = signal<string>('');
  selectedCity = signal<string>('');
  selectedState = signal<string>('');

  // Available filter options (can be populated from API or hardcoded)
  cities = signal<string[]>([]);
  states = signal<string[]>([]);

  constructor(private hotelsService: HotelsService) {}

  ngOnInit(): void {
    this.loadHotels();
  }

  async loadHotels(): Promise<void> {
    this.isLoading.set(true);
    this.errorMessage.set('');

    try {
      const params: HotelsFilterParams = {
        pageNumber: this.currentPage(),
        pageSize: this.pageSize(),
      };

      if (this.searchTerm().trim()) {
        params.searchTerm = this.searchTerm().trim();
      }
      if (this.selectedCity()) {
        params.city = this.selectedCity();
      }
      if (this.selectedState()) {
        params.state = this.selectedState();
      }

      const response = await this.hotelsService.getHotels(params);

      this.hotels.set(response.items);
      this.totalCount.set(response.totalCount);
      this.totalPages.set(response.totalPages);
    } catch (error: any) {
      this.errorMessage.set(
        error?.response?.data?.message || 'Failed to load hotels. Please try again later.'
      );
      this.hotels.set([]);
    } finally {
      this.isLoading.set(false);
    }
  }

  onSearch(): void {
    this.currentPage.set(1);
    this.loadHotels();
  }

  onFilterChange(): void {
    this.currentPage.set(1);
    this.loadHotels();
  }

  onPageChange(page: number): void {
    if (page >= 1 && page <= this.totalPages()) {
      this.currentPage.set(page);
      this.loadHotels();
      window.scrollTo({ top: 0, behavior: 'smooth' });
    }
  }

  clearFilters(): void {
    this.searchTerm.set('');
    this.selectedCity.set('');
    this.selectedState.set('');
    this.currentPage.set(1);
    this.loadHotels();
  }

  getPaginationArray(): number[] {
    const total = this.totalPages();
    const current = this.currentPage();
    const pages: number[] = [];

    if (total <= 7) {
      for (let i = 1; i <= total; i++) {
        pages.push(i);
      }
    } else {
      if (current <= 4) {
        for (let i = 1; i <= 5; i++) {
          pages.push(i);
        }
        pages.push(-1); // ellipsis
        pages.push(total);
      } else if (current >= total - 3) {
        pages.push(1);
        pages.push(-1); // ellipsis
        for (let i = total - 4; i <= total; i++) {
          pages.push(i);
        }
      } else {
        pages.push(1);
        pages.push(-1); // ellipsis
        for (let i = current - 1; i <= current + 1; i++) {
          pages.push(i);
        }
        pages.push(-1); // ellipsis
        pages.push(total);
      }
    }

    return pages;
  }

  trackByHotelId(index: number, hotel: Hotel): number {
    return hotel.id;
  }

  // Expose Math for template
  protected readonly Math = Math;
}
