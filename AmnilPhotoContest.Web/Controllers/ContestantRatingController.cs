using AmnilPhotoContest.Business;
using AmnilPhotoContest.Web.Models;
using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmnilPhotoContest.Web.Controllers
{
    public class ContestantRatingController : Controller
    {
        IUnitOfWork unitOfWork;

        public ContestantRatingController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        // GET: ContestantRating
        public ActionResult Index( int pageNumber=1, int pageSize=10)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
                ViewBag.MessageType = TempData["MessageType"];
            }

            
            IEnumerable<ContestantRatingModel> ratingModels = unitOfWork.ContestantRating.GetContestantRating();
            IEnumerable<ContestantRatingDTO> ratings=Mapper.Map<IEnumerable<ContestantRatingDTO>>(ratingModels);
            return View(ratings.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Rate(int id)
        {
            ContestantRatingDTO contestantRating = new ContestantRatingDTO();
            contestantRating.ContestantId = id;
            contestantRating.FullName = unitOfWork.Contestant.Get(id).FirstName + " " + unitOfWork.Contestant.Get(id).LastName;
            contestantRating.PhotoUrl = unitOfWork.Contestant.Get(id).PhotoUrl;
            int districtId = unitOfWork.Contestant.Get(id).DistrictId;
            contestantRating.District = unitOfWork.District.Get(districtId).Name;
            return PartialView("_Rate", contestantRating);
        }

        [HttpPost]
        public ActionResult AddRating(ContestantRatingDTO contestantRating)
        {
            try
            {
                ContestantRating rating = Mapper.Map<ContestantRating>(contestantRating);
                rating.RatedDate = DateTime.Now;
                unitOfWork.ContestantRating.Add(rating);
                unitOfWork.Complete();
            }
            catch (Exception e)
            {
                TempData["Message"] = "Rating failed !";
                TempData["MessageType"] = "danger";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Rating successfull !";
            TempData["MessageType"] = "success";
            return RedirectToAction("Index");

        }
    }
}