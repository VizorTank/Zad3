using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Zad3.Pages
{
    public class SesjaModel : PageModel
    {
        public String BuzzFizz { get; set; }
        public String Data { get; set; }
        public void OnGet()
        {
            BuzzFizz = HttpContext.Session.GetString("BuzzFizz");
            Data = HttpContext.Session.GetString("Data");
        }
    }
}
