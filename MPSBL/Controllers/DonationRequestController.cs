using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPSBL.Models;
using MPSBL.ViewModels;

namespace MPSBL.Controllers
{
    public class DonationRequestController : Controller
    {
        private readonly IDonationRequestRepository _reqRepo;
        private readonly IDonationCenterRepository _centerRepo;

        public DonationRequestController(IDonationRequestRepository reqRepo, IDonationCenterRepository centerRepo)
        {
            _reqRepo = reqRepo;
            _centerRepo = centerRepo;
        }

        public ViewResult List()
        {
            DonationRequestSListViewModel drlvModel = new DonationRequestSListViewModel();
            drlvModel.Requests = _reqRepo.Requests;
            return View(drlvModel);
        }

        [Route("/DonationRequest/Request/{id}")]
        public IActionResult DRequest(int id)
        {
            var request = _reqRepo.GetDonationRequestById(id);
            var model = new RequestViewModel
            {
                req = request,
                centr = _centerRepo.GetDonationCenterByName(request.CenterName)
            };
            return View(model);
        }
    }
}