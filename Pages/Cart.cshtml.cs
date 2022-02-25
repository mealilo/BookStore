using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission7.Models;

namespace Mission7.Pages
{
    public class CartModel : PageModel
    {

        private IBookRepository repo { get; set; }

        public CartModel (IBookRepository temp)
        {
            repo = temp;
        }
        public void OnGet()
        {
        }
    }
}
