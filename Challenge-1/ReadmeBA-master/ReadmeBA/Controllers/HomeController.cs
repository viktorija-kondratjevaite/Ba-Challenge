using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReadmeBA.Models;

namespace ReadmeBA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new BadExample
            {
                Content = "//A lot of content",
                PageTitle = @"Title123
                                //No need",//TestTitle,
            });
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
    }

    public class BadExample
    {
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string Version { get; set; }
    }
}
