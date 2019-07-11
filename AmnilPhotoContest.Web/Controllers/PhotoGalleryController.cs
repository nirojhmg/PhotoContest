using AmnilPhotoContest.Business;
using AmnilPhotoContest.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmnilPhotoContest.Web.Controllers
{
    public class PhotoGalleryController : Controller
    {
        IUnitOfWork unitOfWork;

        public PhotoGalleryController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        // GET: PhotoGallery
        public ActionResult Index()
        {
            IEnumerable<Contestant> contestants = unitOfWork.Contestant.GetAll();
            IEnumerable<ContestantDTO> contestantDTOs = Mapper.Map<IEnumerable<ContestantDTO>>(contestants);
            foreach (var contestant in contestantDTOs)
            {
                contestant.District = unitOfWork.District.Get(contestant.DistrictId).Name;
            }
            return View(contestantDTOs);
        }
    }
}