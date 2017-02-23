using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _365ThreeSixtyAPI.Models;


namespace _365ThreeSixtyAPI.Factories
{
    public class userAccountFactory

    {
        public _365ThreeSixtyAPIContext db = new _365ThreeSixtyAPIContext();
        public userAccount setUpUserAccount(string accountName, string accountEmail, string accountContact)
        {
            userAccount u = new userAccount();

            u.id = Guid.NewGuid().ToString();
            u.accountName = accountName;
            u.accountEmail = accountEmail;
            u.accountContactName = accountContact;

            db.userAccounts.Add(u);
            db.SaveChanges();

            return u;


        }
    }
}