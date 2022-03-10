using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class Donation
    {

        [Key]
        [BindNever]
        public int DonationId { get; set; }


        [BindNever]
        public ICollection<ShoppingCartItem> Lines { get; set; }


        [Required(ErrorMessage = "Please enter a name:")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please enteraddress")]

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }


        [Required(ErrorMessage = "Please enter city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter Zip")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter Country")]
        public string Country { get; set; }

        [BindNever]
        public bool OrderShipped { get; set; }
    }
}
