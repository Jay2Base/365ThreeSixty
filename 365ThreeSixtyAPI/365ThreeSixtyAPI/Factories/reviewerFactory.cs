using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _365ThreeSixtyAPI.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.Data;
using System.Reflection;

namespace _365ThreeSixtyAPI.Factories
{
    public class reviewerFactory
    {
        public _365ThreeSixtyAPIContext db = new _365ThreeSixtyAPIContext();
        reviewer rev = new reviewer();

        public reviewer createReviewer(string email)
        {

            rev.Ref = db.employee.Where(x => x.email == email).Select(x => x.id).FirstOrDefault();
            rev.tier = db.employee.Where(x => x.id == rev.Ref).Select(x => x.tier).FirstOrDefault();
            rev.team = db.employee.Where(x => x.id == rev.Ref).Select(x => x.team).FirstOrDefault();
            rev.email = email;
            
            return rev;
        }
    }
}