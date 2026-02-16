import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class WeatherService {

  constructor(private http: HttpClient) {}

  syncWeather(locationId: number) {
    return this.http.post(
      `${environment.apiUrl}/weather/sync/${locationId}`, 
      {}
    );
  }

  getWeather(locationId: number) {
    return this.http.get(
      `${environment.apiUrl}/weather/${locationId}`
    );
  }
}
