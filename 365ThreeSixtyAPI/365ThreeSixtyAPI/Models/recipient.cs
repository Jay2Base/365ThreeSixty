using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _365ThreeSixtyAPI.Models
{
    public class recipient
    {
        public int Ref { get; set; }
        public string email { get; set; }
        public int tier { get; set; }
        public int team { get; set; }
        public int reviewsInLastSevenDays { get; set; }
    }
}