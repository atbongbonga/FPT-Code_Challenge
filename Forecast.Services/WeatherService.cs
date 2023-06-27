using Forecast.Models.DTO;
using Forecast.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Forecast.Services
{
    public class WeatherService : IWeatherRepository
    {

        public WeatherDTO GetWeather(string CityName)
        {

            var weather = new WeatherDTO();

            string apiKey = "4d23490cab80eb1ea77b141942e8cb45";

            HttpClient client = new HttpClient();

            string requestUrl = "http://api.weatherstack.com/current?access_key=" + apiKey + "&query=" + CityName;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            HttpResponseMessage response = client.SendAsync(request).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                weather = JsonConvert.DeserializeObject<WeatherDTO>(responseBody);
            }
            return weather;

        }

        public string GetCityName(string ZipCode)
        {

            HttpClient client = new HttpClient();

            string requestUrl = "https://ziptasticapi.com/" + ZipCode;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            HttpResponseMessage response = client.SendAsync(request).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var country = JsonConvert.DeserializeObject<CountryDTO>(responseBody);

                return country.city;
            }
            else
            {
                return null;
            }

        }

    }
}
