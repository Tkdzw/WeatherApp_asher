import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../weather/weather.service';
import { CommonModule } from '@angular/common';
import { WeatherCardComponent } from '../../components/weather-card.component';
import { LocationService } from '../locations/location.service';

@Component({
  standalone: true,
  imports: [CommonModule, WeatherCardComponent],
  template: `
    <h1>Dashboard</h1>

    <div *ngIf="weatherList.length === 0">
      No weather data yet.
    </div>

    <div class="grid">
      <app-weather-card
        *ngFor="let weather of weatherList"
        [weather]="weather">
      </app-weather-card>
    </div>
  `,
  styles: [`
    .grid {
      display:grid;
      grid-template-columns: repeat(auto-fill, minmax(250px,1fr));
      gap:1rem;
    }
  `]
})
export class DashboardComponent implements OnInit {

  weatherList: any[] = [];

  constructor(private locationService: LocationService) {}

 ngOnInit() {
  this.loadWeather();
  setInterval(() => this.loadWeather(), 60000);
}


loadWeather() {
    this.locationService.getWithWeather()
      .subscribe({
        next: (res) => {
          this.weatherList = res;
        },
        error: () => {
        }
      });
  }

}
