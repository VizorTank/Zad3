using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;


namespace Zad3.Pages
{
    public class SzukaneModel : PageModel
    {
        public String BuzzFizz { get; set; }
        public String Data  { get; set; }
        public void OnGet()
        {
            BuzzFizz = HttpContext.Session.GetString("BuzzFizz");
            Data = HttpContext.Session.GetString("Data");
        }
    }
}
