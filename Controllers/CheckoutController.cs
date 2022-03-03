﻿using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class CheckoutController : Controller
    {
        
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new DonationInfo());
        }
    }
}
