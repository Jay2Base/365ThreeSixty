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
    public class employeeController : ApiController
    {
        private _365ThreeSixtyAPIContext db = new _365ThreeSixtyAPIContext();

        // GET: api/employee
        public IQueryable<employee> Getemployee(string userAccountId)
        {
                

                return db.employee.Where(x => x.UserAccountId == userAccountId);
        
        }


        
        // GET: api/employee/5
        [ResponseType(typeof(employee))]
        public async Task<IHttpActionResult> Getemployee(int id)
        {
            
            employee employee = await db.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/employee/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemployee(int id, employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
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

        // POST: api/employee
        [ResponseType(typeof(employee))]
        public async Task<IHttpActionResult> Postemployee(employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.employee.Add(employee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employee.id }, employee);
        }

        // DELETE: api/employee/5
        [ResponseType(typeof(employee))]
        public async Task<IHttpActionResult> Deleteemployee(int id)
        {
            employee employee = await db.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.employee.Remove(employee);
            await db.SaveChangesAsync();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeExists(int id)
        {
            return db.employee.Count(e => e.id == id) > 0;
        }
    }
}