using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Application.DTOs.Locations
{
    public class UserLocationDto
    {
              
        // FK to Location (One-to-One)
        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public bool IsFavourite { get; set; } = false;
          }
}
