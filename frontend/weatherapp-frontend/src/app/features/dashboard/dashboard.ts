import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocationService } from '../locations/location.service';
import { LocationWithWeather } from '../../models/location-with-weather.model';

@Component({
  standalone: true,
  imports: [CommonModule],
  template: `
    <h1>Dashboard</h1>

    <div *ngIf="loading()">Loading weather...</div>

    <div class="grid">
      <div class="card" *ngFor="let location of locations()">

        <h3>{{ location.city }}, {{ location.country }}</h3>

        <ng-container *ngIf="location.weather; else noWeather">
          <p>🌡 {{ location.weather.temperature }} °C</p>
          <p>Feels Like: {{ location.weather.feelsLike }} °C</p>
          <p>{{ location.weather.description }}</p>
          <p>💧 Humidity: {{ location.weather.humidity }}%</p>
          <p>🌬 Wind: {{ location.weather.windSpeed }} m/s</p>
          <small>
            {{ location.weather.timestamp | date:'short' }}
          </small>
        </ng-container>

        <ng-template #noWeather>
          <p>No weather data yet.</p>
        </ng-template>

      </div>
    </div>
  `,
  styles: [`
    .grid {
      display:grid;
      grid-template-columns: repeat(auto-fill, minmax(280px,1fr));
      gap:1rem;
    }
    .card {
      padding:1rem;
      border-radius:12px;
      box-shadow:0 2px 8px rgba(0,0,0,0.1);
      background:white;
    }
  `]
})
export class DashboardComponent implements OnInit {

  locations = signal<LocationWithWeather[]>([]);
  loading = signal(true);

  constructor(private locationService: LocationService) {}

  ngOnInit() {
    this.locationService.getWithWeather()
      .subscribe({
        next: res => {
          this.locations.set(res);
          this.loading.set(false);
        },
        error: () => this.loading.set(false)
      });
  }
}
