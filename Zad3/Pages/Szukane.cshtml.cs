using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Zad3.Models;
using Zad3.Data;

namespace Zad3.Pages
{
    public class SzukaneModel : PageModel
    {
        public IList<BuzzFizz> BF { get; set; }
        private readonly BuzzFizzContext _context;
        public int a { get; set; }

        public SzukaneModel(BuzzFizzContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var BuzzFizzQuerry = (from BuzzFizz in _context.BuzzFizz orderby BuzzFizz.date descending select BuzzFizz).Take(10);
            BF = BuzzFizzQuerry.ToList();
        }

        public IActionResult OnPost(int itemId)
        {
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
    }
}
