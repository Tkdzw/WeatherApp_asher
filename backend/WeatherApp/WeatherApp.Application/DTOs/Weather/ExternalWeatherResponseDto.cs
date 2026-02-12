using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Application.DTOs.Weather
{
    public class ExternalWeatherResponseDto
    {
        public decimal Temperature { get; set; }
        public string Description { get; set; }
    }
}
