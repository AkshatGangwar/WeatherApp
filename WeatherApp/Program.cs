using System;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the city name: ");
            string? city = Console.ReadLine();

            Weather weather= new Weather();
            CityList cityList = weather.GetLatLang(city);
            WeatherData weatherData= weather.GetWeatherData(cityList);

            // Print the result
            Console.WriteLine("Temperature: " + weatherData.current_weather.temperature + "°C");
            Console.WriteLine("Wind Speed: " + weatherData.current_weather.windspeed + "m/s");
            Console.WriteLine("Wind Direction: " + weatherData.current_weather.winddirection + "°");
            Console.WriteLine("Weather Code: " + weatherData.current_weather.weathercode);
            Console.ReadLine();
        }
    }
}
    