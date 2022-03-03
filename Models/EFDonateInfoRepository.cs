using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class EFDonateInfoRepository : IDonateInfoRepository
    {
        private BookstoreContext context;
        public EFDonateInfoRepository(BookstoreContext temp)
        {
             context = temp;
        }

        public IQueryable<DonationInfo> DonationInfo => context.DonationInfo.Include(x => x.Lines).ThenInclude(x => x.Items);

        public void SaveDonation(DonationInfo donationinfo)
        {
            context.AttachRange(donationinfo.Lines.Select(x => x.Items));

        }
    }
}
