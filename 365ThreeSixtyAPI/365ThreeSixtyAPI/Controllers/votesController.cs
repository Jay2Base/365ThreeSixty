using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using _365ThreeSixtyAPI.Models;

namespace _365ThreeSixtyAPI.Controllers
{
    public class votesController : ApiController
    {
        private _365ThreeSixtyAPIContext db = new _365ThreeSixtyAPIContext();

        // GET: api/votes
        public IQueryable<vote> Getvote()
        {
           
                return db.vote;
              
        }

        // GET: api/votes/5
        [ResponseType(typeof(vote))]
        public async Task<IHttpActionResult> Getvote(int id)
        {
            vote vote = await db.vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }

            return Ok(vote);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool voteExists(int id)
        {
            return db.vote.Count(e => e.id == id) > 0;
        }
    }
}