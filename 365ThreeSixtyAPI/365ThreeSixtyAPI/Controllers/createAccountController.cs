using System.Web.Http;
using _365ThreeSixtyAPI.Factories;

namespace _365ThreeSixtyAPI.Controllers
{
    public class createAccountController : ApiController
    {
        // GET: api/createAccount

        public string GetCreateUserAccount(string accountName, string accountEmail, string accountContact)
        {
            userAccountFactory f = new userAccountFactory();
            string newAccountId = f.setUpUserAccount(accountName, accountEmail, accountContact);
            return newAccountId;

        }

       
    }
}
