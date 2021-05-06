using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Zad3.Models;
using Zad3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Zad3.Pages
{
    [Authorize]

    public class SzukaneModel : PageModel
    {
        public IList<BuzzFizz> BF { get; set; }
        private readonly BuzzFizzContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public int a { get; set; }

        public SzukaneModel(BuzzFizzContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void OnGet()
        {
            var BuzzFizzQuerry = (from BuzzFizz in _context.BuzzFizz orderby BuzzFizz.date descending select BuzzFizz).Take(20);
            BF = BuzzFizzQuerry.ToList();
        }

        public IActionResult OnPost(int itemId, string userId)
        {
            if (userId != null && userId.CompareTo(GetUserId()) == 0)
                DelBuzzFizz(itemId);
            return RedirectToPage("./Szukane");
        }

        public void DelBuzzFizz(int n)
        {
            var BuzzFizzQuerry = (from BuzzFizz in _context.BuzzFizz where BuzzFizz.Id == n && BuzzFizz.historical == false orderby BuzzFizz.date descending select BuzzFizz).FirstOrDefault();
            if (BuzzFizzQuerry != null)
            {
                _context.BuzzFizz.Remove(BuzzFizzQuerry);
                _context.SaveChanges();
            }
        }

        public string GetUserId()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
    }
}
