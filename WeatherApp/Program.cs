using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the city name: ");
            string city = Console.ReadLine();

            // Get the latitude and longitude of the city
            // You would need to write additional code here to fetch the latitude and longitude of the city based on the user's input
            // For this example, let's assume the latitude and longitude are as follows:
            double latitude = 18.9667;
            double longitude = 72.8333;

            // Call the API to retrieve the weather information
            var client = new HttpClient();
            var result = client.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=" + latitude + "&longitude=" + longitude + "&current_weather=true").Result;

            // Parse the JSON result
            dynamic weatherData = JsonConvert.DeserializeObject(result);

            // Extract the required information, such as temperature and wind speed
            double temperature = weatherData.current_weather.temperature;
            double windSpeed = weatherData.current_weather.windspeed;

            // Print the result
            Console.WriteLine("Temperature: " + temperature + "°C");
            Console.WriteLine("Wind Speed: " + windSpeed + "m/s");
            Console.ReadLine();
        }
    }
}
