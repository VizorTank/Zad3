using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zad3.Models
{
    public class BuzzFizz
    {
        public int Id { get; set; }
        [Required]
        public int number { get; set; }
        [Required]
        [MaxLength(20)]
        public string date { get; set; }
        [Required]
        public bool historical { get; set; }
        public BuzzFizz(int n)
        {
            number = n;
            date = DateTime.Now.ToString();
            historical = false;
        }

        public BuzzFizz()
        {
            number = 1;
            date = DateTime.Now.ToString();
            historical = false;
        }

        public override string ToString()
        {
            String output = "";
            if (number % 3 == 0)
                output = "" + "Fizz";
            if (number % 5 == 0)
                output = output + "Buzz";
            if (output == "")
                output = "Liczba: " + number + " nie spełnia kryteriów Fizz/Buzz";
            else
                output = "Otrzymano: " + output;
            
            return output;
        }
    }
}
