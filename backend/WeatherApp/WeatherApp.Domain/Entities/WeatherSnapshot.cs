using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Domain.Entities
{
   public class WeatherSnapshot
{
    public int Id { get; set; }
    public int LocationId { get; set; }
    public decimal Temperature { get; set; }
    public string Description { get; set; }
    public DateTime Timestamp { get; set; }
}

}
