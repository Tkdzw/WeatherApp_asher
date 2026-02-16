import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class LocationService {

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get(`${environment.apiUrl}/weather/locations`);
  }

  create(data: any) {
    return this.http.post(`${environment.apiUrl}/weather/locations`, data);
  }

  syncWeather(id: number) {
    return this.http.post(
      `${environment.apiUrl}/weather/sync/${id}`,
      {}
    );
  }
}
