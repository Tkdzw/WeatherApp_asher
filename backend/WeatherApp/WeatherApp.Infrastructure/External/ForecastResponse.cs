using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Infrastructure.External
{
    public class ForecastResponse
    {
        public DateTime DateTime { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public double Precipitation { get; set; }
    }
}
