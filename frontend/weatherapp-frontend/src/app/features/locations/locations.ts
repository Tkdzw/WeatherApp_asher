import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LocationService } from './location.service';
import { LocationWithWeather } from '../../models/location-with-weather.model';

@Component({
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <h1>Locations</h1>

    <!-- Add Location Form -->
    <form (ngSubmit)="addLocation()" class="form">
      <input
        [(ngModel)]="city"
        name="city"
        placeholder="City"
        required />

      <input
        [(ngModel)]="country"
        name="country"
        placeholder="Country"
        required />

      <button type="submit">Add</button>
    </form>

    <div *ngIf="loading()">Loading...</div>

    <!-- Location List -->
    <div class="grid">
      <div class="card" *ngFor="let loc of locations()">

        <h3>{{ loc.city }}, {{ loc.country }}</h3>

        <ng-container *ngIf="loc.weather; else noWeather">
          <p>🌡 {{ loc.weather.temperature }} °C</p>
          <p>{{ loc.weather.description }}</p>
          <small>
            {{ loc.weather.timestamp | date:'short' }}
          </small>
        </ng-container>

        <ng-template #noWeather>
          <p>No weather synced yet.</p>
        </ng-template>

        <button (click)="sync(loc.id)">
          Sync Weather
        </button>

      </div>
    </div>
  `,
  styles: [`
    .form {
      margin-bottom: 2rem;
      display:flex;
      gap:1rem;
    }
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
    button {
      margin-top:1rem;
    }
  `]
})
export class LocationsComponent implements OnInit {

  locations = signal<LocationWithWeather[]>([]);
  loading = signal(true);

  city = '';
  country = '';

  constructor(private locationService: LocationService) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.locationService.getAll()
      .subscribe({
        next: res => {
          this.locations.set(res);
          this.loading.set(false);
        },
        error: () => this.loading.set(false)
      });
  }

  addLocation() {
    this.locationService.create({
      city: this.city,
      country: this.country
    }).subscribe(() => {
      this.city = '';
      this.country = '';
      this.load();
    });
  }

  sync(id: number) {
    this.locationService.syncWeather(id)
      .subscribe(() => {
        this.load();
      });
  }
}
