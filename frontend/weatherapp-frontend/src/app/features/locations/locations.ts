import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LocationService } from './location.service';

@Component({
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <h1>Locations</h1>

    <form (ngSubmit)="addLocation()">
      <input [(ngModel)]="city" name="city" placeholder="City" required>
      <input [(ngModel)]="country" name="country" placeholder="Country" required>
      <button type="submit">Add</button>
    </form>

    <div *ngFor="let loc of locations" class="location">
      <strong>{{ loc.city }}</strong>
      <button (click)="sync(loc.id)">Sync Weather</button>
    </div>
  `,
  styles:[`
    .location {
      margin-top:1rem;
      padding:1rem;
      border:1px solid #ddd;
      border-radius:8px;
    }
  `]
})
export class LocationsComponent implements OnInit {

  locations: any[] = [];
  city = '';
  country = '';

  constructor(private locationService: LocationService) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.locationService.getAll()
      .subscribe(res => this.locations = res as any[]);
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
      .subscribe();
  }
}
