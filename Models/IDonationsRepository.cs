using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public interface IDonationsRepository
    {

        public IQueryable<Donation> Donations { get; set; }
        public void SaveDonation(Donation donation);
    }
}
