using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<WeatherSnapshot> WeatherSnapshots { get; set; }
    }
}
