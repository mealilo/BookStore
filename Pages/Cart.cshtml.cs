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

        public Cart Cart { get; set; }
        public string ReturnURL { get; set; }

        public void OnGet(string returnURL)
        {
            ReturnURL = returnURL ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }

        public IActionResult OnPost(int BookId, string returnURL)
        {
            Book book = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            Cart.AddItem(book, 1);

            return RedirectToPage(new { ReturnURL = returnURL });
        }

        public IActionResult OnPostRemove(int BookId, string returnURL)
        {
            Book book = Cart.Items.First(x => x.Book.BookId == BookId).Book;
            Cart.RemoveItem(book);

            return RedirectToPage(new { ReturnURL = returnURL });
        }
    }
}
