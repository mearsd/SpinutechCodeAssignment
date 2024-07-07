using Microsoft.AspNetCore.Mvc;
using SpinutechCodeAssignment.Models;
using System.Diagnostics;

namespace SpinutechCodeAssignment.Controllers
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
            return View(new Exercise6Model());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckExercise6InputPost(Exercise6Model model)
        {
            //First, check the input is valid
            int numInput = -1;
            if (!int.TryParse(model.InputText, out numInput) || numInput < 1) {
                model.OutputText = "Please provide a positive number as input";
                return View("Index", model);
            }

            //If valid input, set up algorithm and response
            char[] input = model.InputText.ToCharArray();
            model.OutputText = "This number is a palindrome.";

            /* 
             * The algorithm for checking for a palindrome is simple.
             * Check the first and last characters of the string to see if they are equal
             * Next check the second and second to last characters to see if the are equal
             * Repeat until the characters you are checking have passed the middle (the indexes are equal or have flipped)
             * If they are ever not equal, change the response, stop checking
             */
            for (int i = 0, j = input.Length - 1; i <= j; i++, j--) {
                if (input[i] != input[j])
                {
                    model.OutputText = "This number is not a palindrome.";
                    break;
                }
            }

            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
