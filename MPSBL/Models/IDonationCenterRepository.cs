using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSBL.Models
{
    public interface IDonationCenterRepository
    {
        IEnumerable<DonationCenter> Centers { get; }

        DonationCenter GetDonationCenterById(int centerId);
        DonationCenter GetDonationCenterByName(string centerName);



    }
}
