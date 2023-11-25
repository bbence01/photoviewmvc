using Microsoft.AspNetCore.Mvc;
using photoviewmvc.Models;
using System.Diagnostics;

namespace photoviewmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;

        }

        public IActionResult Index()
        {
            var jpgFiles = Directory.EnumerateFiles(Path.Combine(_hostingEnvironment.WebRootPath), "*.jpg")
                                    .Select(Path.GetFileName)
                                    .ToList();

            return View(jpgFiles);
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
}