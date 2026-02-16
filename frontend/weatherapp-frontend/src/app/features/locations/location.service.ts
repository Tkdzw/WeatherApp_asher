import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { LocationWithWeather } from '../../models/location-with-weather.model';

@Injectable({ providedIn: 'root' })
export class LocationService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<LocationWithWeather[]>(`${environment.apiUrl}/weather/locations`);
  }

  create(data: any) {
    return this.http.post(`${environment.apiUrl}/weather/locations`, data);
  }

  getWithWeather() {
    return this.http.get<any[]>(
      `${environment.apiUrl}/weather/locations/with-weather`
    );
  }


  syncWeather(id: number) {
    return this.http.post(
      `${environment.apiUrl}/weather/${id}/sync`,
      {}
    );
  }
}
