using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission7.Models;
using Microsoft.AspNetCore.Http.Json;
using Mission7.Infrastructure;

namespace Mission7.Pages
{
    public class CartModel : PageModel
    {

        private IBookRepository repo { get; set; }

        public CartModel (IBookRepository temp)
        {
            repo = temp;
        }

        public Cart cart { get; set; }
        public string ReturnURL { get; set; }

        public void OnGet(string returnURL)
        {
            ReturnURL = returnURL ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(string isbn, string returnURL)
        {
            Book book = repo.Books.FirstOrDefault(x => x.Isbn == isbn);

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", cart);
            return RedirectToPage(new { ReturnURL = returnURL });
        }
    }
}
