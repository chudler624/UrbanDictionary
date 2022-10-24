using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrbanDictionary.Models;
using UrbanDictionary.UrbanDictionaryApi;

namespace UrbanDictionary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult WordResults(string word)
        {
            var urbanApi = new UrbanApi();
            var wordModels = urbanApi.GetWordInfo(word);


            return View(wordModels);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}