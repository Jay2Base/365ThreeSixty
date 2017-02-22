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
using _365ThreeSixtyAPI.Factories;

namespace _365ThreeSixtyAPI.Controllers
{
    public class userAccountsController : ApiController
    {
        private _365ThreeSixtyAPIContext db = new _365ThreeSixtyAPIContext();

        // GET: api/userAccounts
        public IQueryable<userAccount> Getaccounts()
        {
            return db.userAccounts;
        }

        // GET: api/userAccounts/5
        [ResponseType(typeof(userAccount))]
        public async Task<IHttpActionResult> GetuserAccount(string id)
        {
            userAccount userAccount = await db.userAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return Ok(userAccount);
        }


        // PUT: api/userAccounts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutuserAccount(string id, userAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAccount.id)
            {
                return BadRequest();
            }

            db.Entry(userAccount).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userAccountExists(id))
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

        // POST: api/userAccounts
        [ResponseType(typeof(userAccount))]
        public async Task<IHttpActionResult> PostuserAccount(userAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.userAccounts.Add(userAccount);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (userAccountExists(userAccount.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userAccount.id }, userAccount);
        }

        // DELETE: api/userAccounts/5
        [ResponseType(typeof(userAccount))]
        public async Task<IHttpActionResult> DeleteuserAccount(string id)
        {
            userAccount userAccount = await db.userAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            db.userAccounts.Remove(userAccount);
            await db.SaveChangesAsync();

            return Ok(userAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userAccountExists(string id)
        {
            return db.userAccounts.Count(e => e.id == id) > 0;
        }
    }
}