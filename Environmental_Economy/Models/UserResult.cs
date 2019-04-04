using System;
using System.Collections.Generic;

namespace EnvironmentalEconomy.Models
{
    public class UserResult
    {
        public int ResultId { get; set; }
        public string TokenId { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double AirQuality { get; set; }

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
        public double AirQuality { get; set; }

        public ResultViewModel()
        {
        }

        public Location GetLocation()
        {
            return new Location(Latitude, Longtitude);
        }
    }

    public class ResultDbModel
    {
        public string Token { get; set; }
        public List<UserResult> Results { get; set; }

        public ResultDbModel(string Token)
        {
            this.Token = Token;
            this.Results = new List<UserResult>();
        }
    }
}
