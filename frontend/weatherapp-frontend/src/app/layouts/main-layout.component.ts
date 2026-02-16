import { Component } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  template: `
    <div class="layout">
      <header>
        <h2>WeatherApp</h2>

        <nav>
          <a routerLink="/">Dashboard</a>
          <a routerLink="/locations">Locations</a>
          <button (click)="logout()">Logout</button>
        </nav>
      </header>

      <main>
        <router-outlet></router-outlet>
      </main>
    </div>
  `,
  styles: [`
    header {
      display:flex;
      justify-content:space-between;
      align-items:center;
      padding:1rem;
      background:#1976d2;
      color:white;
    }
    nav a, nav button {
      margin-left:1rem;
      color:white;
      background:none;
      border:none;
      cursor:pointer;
    }
    main { padding:2rem; }
  `]
})
export class MainLayoutComponent {
  constructor(private auth: AuthService) {}
  logout() { this.auth.logout(); }
}
