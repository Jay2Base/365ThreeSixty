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
    public class missionsController : ApiController
    {
        private _365ThreeSixtyAPIContext db = new _365ThreeSixtyAPIContext();

        // GET: api/missions
        public IQueryable<mission> Getmission()
        {
            return db.mission;
        }

        // GET: api/missions/5
        [ResponseType(typeof(mission))]
        public async Task<IHttpActionResult> Getmission(int id)
        {
            mission mission = await db.mission.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            return Ok(mission);
        }



        // POST: api/missions
        [ResponseType(typeof(mission))]
        public async Task<IHttpActionResult> Postmission(mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mission.Add(mission);
            await db.SaveChangesAsync();

            //do the comment stuff
            missionFactory f = new missionFactory();
            f.updateMissionKeywords(mission);

            return CreatedAtRoute("DefaultApi", new { id = mission.id }, mission);
        }

        // DELETE: api/missions/5
        [ResponseType(typeof(mission))]
        public async Task<IHttpActionResult> Deletemission(int id)
        {
            mission mission = await db.mission.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            db.mission.Remove(mission);
            await db.SaveChangesAsync();

            return Ok(mission);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool missionExists(int id)
        {
            return db.mission.Count(e => e.id == id) > 0;
        }
    }
}