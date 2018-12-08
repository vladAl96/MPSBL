using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSBL.Models
{
    public interface IDonationRequestRepository
    {
        IEnumerable<DonationRequest> Requests { get; }

        DonationRequest GetDonationRequestById(int reqId);
        void AddRequest(DonationRequest req);
    }
}
