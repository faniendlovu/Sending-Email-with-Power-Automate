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

                HttpResponseMessage response = await client.PostAsync("Insert URL from Power Automate", content);

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