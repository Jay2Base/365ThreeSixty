using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _365ThreeSixtyAPI.Models;
using _365ThreeSixtyAPI.Factories;

namespace _365ThreeSixtyAPI.Controllers
{
    public class recipientController : ApiController
    {
        // GET: api/recipient
        public recipient Get(string email,string accountId)
        {
            recipientFactory r = new recipientFactory();
                return r.createRecipient(email,accountId);
        }

        
    }
}
