using LocRepro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace LocRepro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/bad")]
        public async Task<IActionResult> Index(int id)
        {
            var item = await Task.Run(() => new object());
            return View(null);
        }

        [Route("/good")]
        public async Task<IActionResult> Index(string id)
        {
            var item = await Task.FromResult(new object());
            return View(null);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            SetLanguage("am");
            base.OnActionExecuted(context);
        }

        private void SetLanguage(string lang)
        {
            var cultureInfo = new CultureInfo(lang);

            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }
    }
}
