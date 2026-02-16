using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Application.DTOs.Users
{
    public class UserPreferenceDto
    {
        public string Units { get; set; } = "metric"; // metric | imperial

        public int RefreshIntervalMinutes { get; set; } = 30;
    }
}
