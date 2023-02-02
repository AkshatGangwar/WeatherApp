using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherData
    {
        public CurrentWeather? current_weather { get; set; }
    }
    public class CurrentWeather
    {
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public double winddirection { get; set; }
        public int weathercode { get; set; }
        public DateTime time { get; set; }
    }
}
