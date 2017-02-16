using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _365ThreeSixtyAPI.Factories;
using _365ThreeSixtyAPI.Models;

namespace _365ThreeSixtyAPI.Controllers
{
    public class reviewerController : ApiController
    {
        // GET: api/reviewer
       
        public reviewer Get(string email)
        {
            reviewerFactory r = new reviewerFactory();
                return r.createReviewer(email);
        }

        // GET: api/reviewer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/reviewer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/reviewer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/reviewer/5
        public void Delete(int id)
        {
        }
    }
}
