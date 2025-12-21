export interface Hotel {
  id: number;
  hotelCode: string;
  name: string;
  address: string;
  city: string;
  state: string;
  zipCode: string;
  phoneNumber: string;
  companyMailAddress: string;
  websiteAddress: string;
  isDeleted: boolean;
  createdAtUtc: string;
  modifiedAtUtc: string | null;
}

export interface HotelsPagedResponse {
  items: Hotel[];
  totalCount: number;
  pageNumber: number;
  pageSize: number;
  totalPages: number;
}

export interface HotelsFilterParams {
  searchTerm?: string;
  city?: string;
  state?: string;
  pageNumber?: number;
  pageSize?: number;
}
