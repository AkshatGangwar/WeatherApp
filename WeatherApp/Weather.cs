using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp
{
    public class Weather
    {
        public CityList GetLatLang(string city)
        {
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true,
            };
            try
            {
                List<CityList>? cityLists = JsonSerializer.Deserialize<List<CityList>>(File.ReadAllText(path:"cityList.json"),options);
                CityList? cityList = cityLists?.Where(x=>x.City.ToLower() == city.ToLower()).First();
                if (cityList is null)
                {
                    throw new NullReferenceException(message: "City Not Found!");
                }
                return cityList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public WeatherData GetWeatherData(CityList cityList)
        {
            var client = new HttpClient();
            string apiUrl = "https://api.open-meteo.com/v1/forecast?";
            try
            {
                var result = client.GetStringAsync(apiUrl + "latitude=" + cityList.Lat + "&longitude=" + cityList.Lng + "&current_weather=true").Result;
                WeatherData? weatherData = JsonSerializer.Deserialize<WeatherData>(result);
                if (weatherData is null)
                {
                    throw new NullReferenceException(message: "Details Not Found!");
                }
                return weatherData;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
