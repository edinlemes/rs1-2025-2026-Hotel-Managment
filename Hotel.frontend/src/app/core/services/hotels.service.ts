import { Injectable } from '@angular/core';
import { axiosInstance } from '../http/axios.config';
import { Hotel, HotelsPagedResponse, HotelsFilterParams } from '../../shared/models/hotel.model';

@Injectable({
  providedIn: 'root',
})
export class HotelsService {
  private readonly baseUrl = '/hotels';

  async getHotels(params: HotelsFilterParams = {}): Promise<HotelsPagedResponse> {
    try {
      const queryParams: Record<string, string | number> = {};

      if (params.searchTerm) {
        queryParams['searchTerm'] = params.searchTerm;
      }
      if (params.city) {
        queryParams['city'] = params.city;
      }
      if (params.state) {
        queryParams['state'] = params.state;
      }
      if (params.pageNumber !== undefined) {
        queryParams['pageNumber'] = params.pageNumber;
      }
      if (params.pageSize !== undefined) {
        queryParams['pageSize'] = params.pageSize;
      }

      const response = await axiosInstance.get<HotelsPagedResponse>(this.baseUrl, {
        params: queryParams,
      });

      return response.data;
    } catch (error) {
      console.error('Failed to fetch hotels:', error);
      throw error;
    }
  }

  async getHotelById(id: number): Promise<Hotel> {
    try {
      const response = await axiosInstance.get<Hotel>(`${this.baseUrl}/${id}`);
      return response.data;
    } catch (error) {
      console.error(`Failed to fetch hotel with id ${id}:`, error);
      throw error;
    }
  }
}
