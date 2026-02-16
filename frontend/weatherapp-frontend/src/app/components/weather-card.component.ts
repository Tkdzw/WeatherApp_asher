import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-weather-card',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="card">
      <h3>{{ weather.city }}</h3>
      <p>🌡 {{ weather.temperature }} °C</p>
      <p>{{ weather.description }}</p>
      <small>{{ weather.recordedAt | date:'short' }}</small>
    </div>
  `,
  styles: [`
    .card {
      padding:1rem;
      border-radius:12px;
      box-shadow:0 2px 8px rgba(0,0,0,0.1);
      background:white;
    }
  `]
})
export class WeatherCardComponent {
  @Input() weather: any;
}
