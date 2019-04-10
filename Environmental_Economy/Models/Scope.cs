using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Environmental_Economy.Models
{
    public class Scope
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }

        public Scope() { }

        public Scope(double Latitude, double Longitude, double Radius)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Radius = Radius;
        }

        public bool CheckNullScope()
        {
            return (this.Latitude == 0 && this.Longitude == 0 && this.Radius == 0);
        }
    }
}