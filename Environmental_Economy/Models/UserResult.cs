using Environmental_Economy.Models;
using System;
using System.Collections.Generic;

namespace EnvironmentalEconomy.Models
{
    public class UserResult
    {
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double AirQuality { get; set; }
        public DateTime Date { get; set; }

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

    public class LocationDetailViewModel
    {
        public Scope scope { get; set; }
        public List<ResultDbModel> Results { get; set; }
    }
}
