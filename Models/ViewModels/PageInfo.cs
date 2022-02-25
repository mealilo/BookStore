using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models.ViewModels
{


    //This page gets the number of books per page, and then calcualtes the total # of pages to be created
    public class PageInfo
    {
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumBooks { get; set; }
        public int TotalPages  => (int) Math.Ceiling( (double) TotalNumBooks / BooksPerPage);
    }
}
