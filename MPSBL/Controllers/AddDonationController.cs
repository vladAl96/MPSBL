using Microsoft.AspNetCore.Mvc;
using MPSBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSBL.Controllers
{
    public class AddDonationController : Controller
    {
        private readonly IDonationRequestRepository _reqRepo;

        public AddDonationController(IDonationRequestRepository reqRepo)
        {
            _reqRepo = reqRepo;
        }
        [HttpPost]
        public IActionResult Add(DonationRequest req)
        {
            if (ModelState.IsValid)
            {
                _reqRepo.AddRequest(req);
                return RedirectToAction("RequestAdded");
            }
            return View(new DonationRequest());
        }

        public IActionResult Add()
        {
            return View(new DonationRequest());
        }

        public IActionResult RequestAdded()
        {
            return View();
        }
    }
}
