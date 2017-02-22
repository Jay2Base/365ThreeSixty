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
using System.Data.Entity;

namespace _365ThreeSixtyAPI.Factories
{
    public class recipientFactory
    {
        public _365ThreeSixtyAPIContext db = new _365ThreeSixtyAPIContext();
        recipient rev = new recipient();

        public recipient createRecipient(string email, string accountId)
        {

            rev.Ref = db.employee.Where(x => x.email == email && x.UserAccountId == accountId).Select(x => x.id).FirstOrDefault();
            rev.tier = db.employee.Where(x => x.id == rev.Ref && x.UserAccountId == accountId).Select(x => x.tier).FirstOrDefault();
            rev.team = db.employee.Where(x => x.id == rev.Ref && x.UserAccountId == accountId).Select(x => x.team).FirstOrDefault();
            rev.email = email;
            rev.reviewsInLastSevenDays = db.vote.Where(x => x.reviewerRef == rev.Ref && x.voteSubmittedAt >= DbFunctions.AddDays(DateTime.Now, -7) && x.userAccountId == accountId).Count();
            return rev;
        }
    }
}