using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSBL.Models
{
    public class DonationRequestRepository : IDonationRequestRepository
    {
        private readonly AppDbContext _appDbContext;
        public IEnumerable<DonationRequest> Requests
        {
            get
            {
                return _appDbContext.Requests;
            }
        }

        public DonationRequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public DonationRequest GetDonationRequestById(int reqId)
        {
            return _appDbContext.Requests.FirstOrDefault(r => r.DonationRequestId == reqId);
        }

        public void AddRequest(DonationRequest req)
        {
            req.DateIssued = DateTime.Now.ToString("MM/dd/yyyy");
            _appDbContext.Requests.Add(req);
            _appDbContext.SaveChanges();
        }
    }
}
