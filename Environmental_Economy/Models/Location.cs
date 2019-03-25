using System;
namespace EnvironmentalEconomy.Models
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

        public Location()
        {
        }

        public Location(double Lat, double Lon)
        {
            this.Latitude = Lat;
            this.Longtitude = Lon;
        }
    }
}
