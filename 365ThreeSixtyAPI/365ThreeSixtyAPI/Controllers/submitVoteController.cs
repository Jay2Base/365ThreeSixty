using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _365ThreeSixtyAPI.Models;
using _365ThreeSixtyAPI.Factories;

using System.Web.Http.Description;
using System.Threading.Tasks;

namespace _365ThreeSixtyAPI.Controllers
{
    public class submitVoteController : ApiController
    {

        // POST: api/submitVote
        [ResponseType(typeof(voteResponse))]
        public IHttpActionResult PostsubmitVote([FromBody]newVote newVote)

        {

            voteFactory vf = new voteFactory();
            voteResponse vr = vf.createVote(newVote);
            return CreatedAtRoute("DefaultAPI", vr, newVote);

        }

    }
}
