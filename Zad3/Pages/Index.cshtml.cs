using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Zad3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty, Range(1, 1000, ErrorMessage = "Liczby of 1 do 1000")]
        public int BuzzFizz { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                String output = "";
                if (BuzzFizz % 3 == 0)
                    output = "" + "Fizz";
                if (BuzzFizz % 5 == 0)
                    output = output + "Buzz";
                if (output == "")
                    output = "Liczba: " + BuzzFizz + " nie spełnia kryteriów Fizz/Buzz";
                else
                    output = "Otrzymano: " + output;

                HttpContext.Session.SetString("BuzzFizz", output);
                HttpContext.Session.SetString("Data", DateTime.Now.ToString());
                return RedirectToPage("./Szukane");
            }
            return Page();
        }
    }
}
