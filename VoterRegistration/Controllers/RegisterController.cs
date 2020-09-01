using Newtonsoft.Json;
using System.Web.Http;
using VoterRegistration.Models;
using VoterRegistration.Services;

namespace VoterRegistration.Controllers
{

    public class RegisterController : ApiController
    {
        RegisterService registerService = new RegisterService();

        // GET api/<controller>/5
        public string Get(int id)
        {
            var response = registerService.GetVoter(id);
            return JsonConvert.SerializeObject(response);
        }

        public string Post([FromBody]Voter voter)
        {
            var response = registerService.RegisterVoter(voter.VoterId, voter.Name);
            return JsonConvert.SerializeObject(response);

        }
    }
}