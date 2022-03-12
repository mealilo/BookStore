﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class EFDonationsRepository : IDonationsRepository
    {

        private BookstoreContext context;
        public EFDonationsRepository(BookstoreContext temp)
        {
            context = temp;
        }

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
