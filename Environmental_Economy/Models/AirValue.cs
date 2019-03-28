using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Environmental_Economy.Models
{
    public class AirValue
    {
        public double MeanTemp { get; set; }
        public double MeanHumd { get; set; }
        public double MeanQual { get; set; }

        public AirValue(double temp, double humd, double qual)
        {
            this.MeanTemp = temp;
            this.MeanHumd = humd;
            this.MeanQual = qual;
        }
    }
}