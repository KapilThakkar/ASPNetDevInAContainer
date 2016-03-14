using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.Mvc;
using System.Text;
using System.Collections;

namespace ASPNetDevInAContainer.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            //var value = _config.GetSection("Foo").GetSection("Bar").Value;
            StringBuilder envVars = new StringBuilder();
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                envVars.Append((string)de.Key + ":" + (string)de.Value + "---" + Environment.NewLine);

            ViewData["EnvVars"] = envVars.ToString();

            ViewData["HostName"] = (Environment.GetEnvironmentVariables()["HOSTNAME"] != null) ?
                Environment.GetEnvironmentVariables()["HOSTNAME"] :
                Environment.GetEnvironmentVariables()["COMPUTERNAME"];

            ViewData["OS"] = (Environment.GetEnvironmentVariables()["OS"] != null) ?
                Environment.GetEnvironmentVariables()["OS"] :
                Environment.GetEnvironmentVariables()["DNX_RUNTIME_ID"];

            ViewData["PROCESSOR_ARCHITEW6432"] = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432");
            ViewData["HOSTING_ENVIRONMENT"] = Environment.GetEnvironmentVariable("Hosting:Environment");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
