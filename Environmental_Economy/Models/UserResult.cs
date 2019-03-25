using System;
namespace EnvironmentalEconomy.Models
{
    public class UserResult
    {
        public int ResultId { get; set; }
        public string TokenId { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public double Tempurature { get; set; }
        public double Humidity { get; set; }
        public double AirQual { get; set; }

        public UserResult()
        {
        }
    }

    public class ResultViewModel
    {
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public double Tempurature { get; set; }
        public double Humidity { get; set; }
        public double AirQual { get; set; }

        public ResultViewModel()
        {
        }

        public Location GetLocation()
        {
            return new Location(Latitude, Longtitude);
        }
    }
}
