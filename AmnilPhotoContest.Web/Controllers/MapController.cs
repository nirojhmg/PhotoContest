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
    public class MapController : Controller
    {
        IUnitOfWork unitOfWork;

        public MapController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        // GET: Map
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetContestantForDistrict(int DistrictId)
        {
            IEnumerable<Contestant> contestants = unitOfWork.Contestant.Find(x => x.DistrictId == DistrictId);
            IEnumerable<ContestantDTO> contestantDTOs = Mapper.Map<IEnumerable<ContestantDTO>>(contestants);
            return Json(contestantDTOs, JsonRequestBehavior.AllowGet);
        }
    }
}