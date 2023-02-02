using WeatherApp;
using WeatherApp.Models;

namespace WeatherAppTest
{
    public class WeatherTest
    {
        Weather weather;
        CityList cityListFetch;
        WeatherData weatherData;
        public WeatherTest() 
        { 
            weather = new Weather();
        }
        [Fact]
        public void Test1()
        {
            cityListFetch = weather.GetLatLang("bareilly");
            Assert.True(cityListFetch != null);
        }
        [Fact]
        public void Test2()
        {
            CityList cityListActual = new CityList();
            cityListActual.City = "Bareilly";
            cityListActual.Lng = "79.4150";
            cityListActual.Lat = "28.3640";
            weatherData = weather.GetWeatherData(cityListActual);
            Assert.True(weatherData != null);
        }
        [Fact]
        public void Test3()
        {
            cityListFetch = weather.GetLatLang("bareilly");
            weatherData = weather.GetWeatherData(cityListFetch);
            Assert.True(weatherData != null);
        }
    }
}