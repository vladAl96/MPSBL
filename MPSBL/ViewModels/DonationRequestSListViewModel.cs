﻿using MPSBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSBL.ViewModels
{
    public class DonationRequestSListViewModel
    {
        public IEnumerable<DonationRequest> Requests { get; set; }
    }
}
