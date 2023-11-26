using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using photoviewmvc.Models;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
namespace photoviewmvc.Controllers
{
    public class ImageModel
    {
        public string FilePath { get; set; }
    }

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
            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Pictures");
            var imageFiles = Directory.EnumerateFiles(imageFolder, "*.jpg");

            var images = new List<ImageModel>();
            foreach (var file in imageFiles)
            {
                images.Add(new ImageModel { FilePath = Path.GetFileName(file) });
            }

            return View(images);
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