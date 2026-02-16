import { Weather } from './weather.model';

export interface LocationWithWeather {
  id: number;
  city: string;
  country: string;
  weather: Weather | null;
}
