using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Models.DTO
{
    public class CurrentDTO
    {
        public string[] weather_descriptions { get; set; }
        public int wind_speed { get; set; }
        public int uv_index { get; set; }
    }
}
