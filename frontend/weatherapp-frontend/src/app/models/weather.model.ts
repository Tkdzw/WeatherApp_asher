export interface Weather {
  temperature: number;
  feelsLike: number;
  description: string;
  icon: string | null;
  humidity: number;
  windSpeed: number;
  timestamp: string;
}
