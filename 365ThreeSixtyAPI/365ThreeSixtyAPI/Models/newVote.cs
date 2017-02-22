using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _365ThreeSixtyAPI.Models
{
    public class newVote
    {
        public string reviewer { get; set;}
        public string recipient { get; set; }
        public string comment { get; set; }
        public string userAccountId { get; set; }
    }
}