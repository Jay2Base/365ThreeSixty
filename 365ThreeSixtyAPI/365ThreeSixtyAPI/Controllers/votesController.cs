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

        // PUT: api/votes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putvote(int id, vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vote.id)
            {
                return BadRequest();
            }

            db.Entry(vote).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!voteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/votes
        [ResponseType(typeof(vote))]
        public async Task<IHttpActionResult> Postvote(vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vote.Add(vote);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vote.id }, vote);
        }

        // DELETE: api/votes/5
        [ResponseType(typeof(vote))]
        public async Task<IHttpActionResult> Deletevote(int id)
        {
            vote vote = await db.vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }

            db.vote.Remove(vote);
            await db.SaveChangesAsync();

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