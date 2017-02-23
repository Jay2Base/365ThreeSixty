using System.Web.Http;
using _365ThreeSixtyAPI.Factories;
using _365ThreeSixtyAPI.Models;

namespace _365ThreeSixtyAPI.Controllers
{
    public class createAccountController : ApiController
    {
        // GET: api/createAccount

        public userAccount GetCreateUserAccount(string accountName, string accountEmail, string accountContact)
        {
            userAccountFactory f = new userAccountFactory();
            userAccount newAccountId = f.setUpUserAccount(accountName, accountEmail, accountContact);
            return newAccountId;

        }

       
    }
}
