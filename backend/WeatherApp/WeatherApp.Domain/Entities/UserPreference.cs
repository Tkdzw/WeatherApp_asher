using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Domain.Entities
{
    public class UserPreference
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Units { get; set; } // metric / imperial
        public int RefreshIntervalMinutes { get; set; }
    }

}
