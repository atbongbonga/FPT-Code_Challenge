

using Forecast;
using Forecast.Models.DTO;
using Forecast.Repositories;
using Forecast.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection().AddSingleton<IWeatherRepository, WeatherService>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var worker = serviceProvider.GetService<IWeatherRepository>();

Console.WriteLine("Your ZipCode:");

string ZipCode = Console.ReadLine();

string CityName = worker.GetCityName(ZipCode);
WeatherDTO weatherDTO = worker.GetWeather(CityName);

if (CityName is null) {
    Console.WriteLine("Invalid ZipCode");
}

if (weatherDTO != null)
{
    Console.WriteLine("Location: ");
    Console.WriteLine("City: " + weatherDTO.location.name);
    Console.WriteLine("Country: " + weatherDTO.location.country);
    Console.WriteLine("Region: " + weatherDTO.location.region);

    Console.WriteLine("Forecast: ");
    Console.WriteLine("Weather: " + string.Join("/", weatherDTO.current.weather_descriptions));
    Console.WriteLine("Wind Speed: " + weatherDTO.current.wind_speed);
    Console.WriteLine("UV Index: " + weatherDTO.current.uv_index);


    Console.WriteLine("Should I go outside?");
    if (!weatherDTO.current.weather_descriptions.Contains("Rain")) { Console.WriteLine("Yes"); }
    else { Console.WriteLine("No");}

    Console.WriteLine("Should I wear sunscreen?");
    if (weatherDTO.current.uv_index > 3) { Console.WriteLine("Yes"); }
    else{ Console.WriteLine("No"); }

    Console.WriteLine("Can I fly my kite?");
    if(!weatherDTO.current.weather_descriptions.Contains("Rain") && weatherDTO.current.wind_speed > 15) { Console.WriteLine("Yes"); }
    else { Console.WriteLine("No"); }

}
else {
    Console.WriteLine("Weather not avaible");
}




