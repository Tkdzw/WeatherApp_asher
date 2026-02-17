using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Application.DTOs.Weather
{
    public class UserLocationsWeatherDto
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public bool IsFavourite { get; set; } = false;
       
        public ICollection<WeatherSnapshot> WeatherSnapshots { get; set; }
        = new List<WeatherSnapshot>();
    }
}
