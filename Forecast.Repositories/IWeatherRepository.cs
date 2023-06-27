using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forecast.Models;
using Forecast.Models.DTO;

namespace Forecast.Repositories
{
    public interface IWeatherRepository
    {
        WeatherDTO GetWeather(string CityName);
        string GetCityName(string ZipCode);
    }

}
