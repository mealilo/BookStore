using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission7.Models;
using Mission7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository repo;

        public HomeController(IBookRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookType,int pageNum = 1)
        {

            int pageSize = 10;

            var data = new BooksViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == bookType || bookType == null)
                //.OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {

                    // If  There is a booktype/.category submitted, then make the correct number of pages
                    TotalNumBooks = (bookType == null ? repo.Books.Count():
                    repo.Books.Where(p => p.Category == bookType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };

            return View(data);
        }


    }
}
