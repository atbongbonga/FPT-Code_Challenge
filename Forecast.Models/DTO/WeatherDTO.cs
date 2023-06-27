using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Models.DTO
{
    public class WeatherDTO
    {
        public CurrentDTO? current { get; set; }
        public LocationDTO location { get; set; }
    }

 
}
