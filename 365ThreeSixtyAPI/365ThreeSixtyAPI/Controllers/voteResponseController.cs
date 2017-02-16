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
    public class voteResponseController : ApiController
    {
        // GET: api/vote
        public voteResponse Getvote()
        {
            voteResponse vote = new Models.voteResponse();
            vote.reviewer = "jay";
            vote.recipient = "kev";
            vote.voteMessage = "this is the message";

            return vote;
        }

        // GET: api/vote?{reviewer={email}&recipient={email}
        public voteResponse Getvote(string reviewer, string recipient, string comment)
        {
            voteResponse vote = new Models.voteResponse();
            vote.reviewer = reviewer;
            vote.recipient = recipient;
            voteFactory v = new voteFactory();
            vote.voteMessage = v.createVote(reviewer, recipient, comment);

            return vote;
        }


    }
}
