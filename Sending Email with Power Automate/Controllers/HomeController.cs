using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sending_Email_with_Power_Automate.Models;
using System.Diagnostics;
using System.Text;

namespace Sending_Email_with_Power_Automate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Contact(ContactUs model)
        {
            if (ModelState.IsValid)
            {
                var client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://prod-108.westus.logic.azure.com:443/workflows/3c15a625b7084931861ceb08e30233b3/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=bM5bCTenm8OvyPMO95FksZTFRsyCZ14fTYxNf8xWe4g", content);

                if (response.IsSuccessStatusCode)
                {
                    // Handle success
                    ViewBag.Message = "Message sent successfully!";
                }
                else
                {
                    // Handle failure
                    ModelState.AddModelError(string.Empty, "Error sending message.");
                }
            }

            return View(model); // Return to the same view, displaying success or error messages as needed
        }



     
    }
}