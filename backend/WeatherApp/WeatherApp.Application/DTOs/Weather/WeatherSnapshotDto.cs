using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Application.DTOs.Weather
{
    public class WeatherSnapshotDto
    {
        public double Temperature { get; set; }

        public double FeelsLike { get; set; }

        public string Description { get; set; } = null!;

        public string Icon { get; set; } = null!;

        public int Humidity { get; set; }

        public double WindSpeed { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
