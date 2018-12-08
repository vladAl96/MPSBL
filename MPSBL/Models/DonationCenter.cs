using System.Collections.Generic;

namespace MPSBL.Models
{
    public class DonationCenter
    {
        public int DonationCenterId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<DonationRequest> AvailableDonations;
    }
}