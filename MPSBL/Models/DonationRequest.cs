using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MPSBL.Models
{
    public class DonationRequest
    {
        public int DonationRequestId { get; set; }

        [Required(ErrorMessage="Please specify doctor")]
        public string Doctor { get; set; }
        [Required(ErrorMessage= "Please specify pacient")]
        public string Pacient { get; set; }
        public string DateIssued { get; set; }
        [Required(ErrorMessage= "Please specify a description for the request")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Please specify center")]
        public string CenterName { get; set; }
        public int numberDonated { get; set; }
        public virtual DonationCenter DonationCenter { get; set; }
    }
}
