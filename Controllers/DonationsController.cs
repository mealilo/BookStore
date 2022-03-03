using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class DonationsController : Controller
    {
        private IDonationsRepository repo { get; set; }

        private Cart cart { get; set; }
        public DonationsController(IDonationsRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }



        //page that loads upon a new checkout!
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Donation());
        }


        //When they submit their contact info, they are all good to go and redirects to the correct page!
        [HttpPost]
        public IActionResult Checkout(Donation donation)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is Empty!");
            }
            if (ModelState.IsValid)
            {
                donation.Lines = cart.Items.ToArray();
                repo.SaveDonation(donation);
                cart.ClearCart();

                return RedirectToPage("/DonationsCompleted");
            }
            else
            {
                return View();
            }
        }
    }

}
