using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// This is the respository that interacts with the db
namespace Mission7.Models
{
    public class EfDonationsRepository : IDonationsRepository
    {
        private BookstoreContext context;
        public EfDonationsRepository(BookstoreContext temp)
        {
            context = temp;
        }

        //connects lines to the book objects

        public IQueryable<Donation> Donations => context.Donations.Include(x => x.Lines).ThenInclude(x => x.Book);

        IQueryable<Donation> IDonationsRepository.Donations { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SaveDonation(Donation donation)
        {
            context.AttachRange(donation.Lines.Select(x => x.Book));

            if (donation.DonationId == 0)
            {
                context.Donations.Add(donation);
            }
            context.SaveChanges();
        }
    }
}
