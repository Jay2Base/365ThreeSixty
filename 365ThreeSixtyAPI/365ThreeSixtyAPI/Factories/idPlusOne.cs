using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _365ThreeSixtyAPI.Factories
{
    public class idPlusOne
    {
        public int returnNextId(int id)
        {
            int newID = id+1;
            return newID;
        }
    }
}