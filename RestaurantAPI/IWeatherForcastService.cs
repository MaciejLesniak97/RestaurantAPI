using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public interface IWeatherForcastService
    {
        IEnumerable<WeatherForecast> Get(int numberOfResults, int minTemp, int maxTemp);
    }
}
