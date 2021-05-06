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
using Zad3.Models;
using Zad3.Data;
using Microsoft.AspNetCore.Identity;

namespace Zad3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BuzzFizzContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty, Range(1, 1000, ErrorMessage = "Liczby of 1 do 1000")]
        public int BuzzFizzNumber { get; set; }
        
        public IndexModel(ILogger<IndexModel> logger, BuzzFizzContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public void OnGet() { }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                BuzzFizz buzzFizz = new BuzzFizz(BuzzFizzNumber, GetUserId());
                AddBuzzFizz(buzzFizz);
                HttpContext.Session.SetString("BuzzFizz", buzzFizz.ToString());
                HttpContext.Session.SetString("Data", buzzFizz.date.ToString());

                return RedirectToPage("./Szukane");
            }
            return Page();
        }

        public void AddBuzzFizz(BuzzFizz buzzFizz)
        {
            var BuzzFizzQuerry = (from BuzzFizz in _context.BuzzFizz where BuzzFizz.historical == false orderby BuzzFizz.date descending select BuzzFizz).Take(10);
            int amount = BuzzFizzQuerry.Count();
            if (amount >= 10)
            {
                var BuzzFizzLast = BuzzFizzQuerry.LastOrDefault();

                if (BuzzFizzLast != null)
                    BuzzFizzLast.historical = true;
            }

            _context.BuzzFizz.Add(buzzFizz);
            _context.SaveChanges();
        }
        public string GetUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
    }
}
