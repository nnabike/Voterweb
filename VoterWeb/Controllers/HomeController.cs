using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using VoterWeb.Models;

namespace VoterWeb.Controllers
{

    public class HomeController : Controller
    {
        private readonly string baseUrl = System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"];
        private readonly string getVoterUri = System.Configuration.ConfigurationManager.AppSettings["GetVoterUri"];
        private readonly string updateVoterUri = System.Configuration.ConfigurationManager.AppSettings["UpdateVoterUri"];

        public async Task<ActionResult> UpdateName(VoterViewModel voter)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", voter);
            }

            if (voter is null)
            {
                throw new ArgumentNullException(nameof(voter));
            }
            
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                
                var response = client.PostAsJsonAsync<VoterViewModel>(updateVoterUri, voter);
                
                if (response.Result.IsSuccessStatusCode)
                {
                    var streamResult = await response.Result.Content.ReadAsStringAsync();
                    var stringResult = JsonConvert.DeserializeObject(streamResult).ToString();
                    var voterResponse = JsonConvert.DeserializeObject<VoterResponse>(stringResult);

                    VoterViewModel viewModel = MapToView(voterResponse);

                    return View("Index", viewModel);
                }
            }
                return View("Contact", voter);
        }

        public async Task<ActionResult> Index()
        {
            string result = string.Empty;
            VoterResponse voterResponse = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(getVoterUri);
                if (response.Result.IsSuccessStatusCode)
                {   
                    var aresult = await response.Result.Content.ReadAsStringAsync();
                    var _voter = JsonConvert.DeserializeObject(aresult).ToString();
                    voterResponse = JsonConvert.DeserializeObject<VoterResponse>(_voter);

                }
            }
            VoterViewModel viewModel = MapToView(voterResponse);

            if (voterResponse != null && voterResponse.Voter != null)
            {
                viewModel = MapToView(voterResponse);
            }

            return View(viewModel);
        }

        private VoterViewModel MapToView(VoterResponse voterResponse)
        {
            return new VoterViewModel { 
                Name = voterResponse.Voter?.Name,
                VoterId = voterResponse.Voter.VoterId, 
                Message = voterResponse.Message 
            };
        }

        public ActionResult About()
        {
            ViewBag.Message = "Contract Services Sample";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
    }
}