using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSBL.Models
{
    public class DonationCenterRepository : IDonationCenterRepository
    {
        private readonly AppDbContext _appDbContext;

        public IEnumerable<DonationCenter> Centers
        {
            get
            {
                return _appDbContext.Centers;
            }
        }

        public DonationCenterRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public DonationCenter GetDonationCenterById(int centerId)
        {
            return _appDbContext.Centers.FirstOrDefault(c => c.DonationCenterId == centerId);
        }

        public DonationCenter GetDonationCenterByName(string centerName)
        {
            return _appDbContext.Centers.FirstOrDefault(c => c.Name.Equals(centerName));
        }
    }
}
