using AmnilPhotoContest.Business;
using AmnilPhotoContest.Web.Models;
using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmnilPhotoContest.Web.Controllers
{
    public class ContestantController : Controller
    {
        IUnitOfWork unitOfWork;

        public ContestantController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        // GET: Contestant
        public ActionResult Index(int pageNumber=1, int pageSize=10)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
                ViewBag.MessageType = TempData["MessageType"];
            }

            IEnumerable<ContestantDTO> contestants = Mapper.Map<IEnumerable<ContestantDTO>>(unitOfWork.Contestant.GetAll());
            foreach (ContestantDTO contestant in contestants)
            {
                contestant.District = unitOfWork.District.Get(contestant.DistrictId).Name;
            }
            return View(contestants.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Add()
        {
            ContestantDTO contestant = new ContestantDTO();
            contestant.Districts = Mapper.Map<IEnumerable<DistrictDTO>>(unitOfWork.District.GetAll());
            return View(contestant);
        }

        [HttpPost]
        public ActionResult Add(ContestantDTO contestant, HttpPostedFileWrapper PhotoUrl)
        {
            try
            {
                Contestant newcontestant = Mapper.Map<Contestant>(contestant);
                // Verify that the user selected a file
                if (PhotoUrl != null && PhotoUrl.ContentLength > 0)
                {
                    // extract only the filename
                    var fileName = Path.GetFileName(PhotoUrl.FileName);
                    // store the file inside /Images/Photos folder
                    var path = Path.Combine(Server.MapPath("~/Images/Photos"), fileName);
                    PhotoUrl.SaveAs(path);
                    newcontestant.PhotoUrl = fileName;
                }
                unitOfWork.Contestant.Add(newcontestant);
                unitOfWork.Complete();
            }
            catch(Exception e)
            {
                TempData["Message"] = "Contestant adding failed !";
                TempData["MessageType"] = "danger";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Contestant added successfully !";
            TempData["MessageType"] = "success";
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            ContestantDTO contestant = Mapper.Map<ContestantDTO>(unitOfWork.Contestant.Get(id));
            contestant.Districts = Mapper.Map<IEnumerable<DistrictDTO>>(unitOfWork.District.GetAll());
            return View(contestant);
        }

        [HttpPost]
        public ActionResult Update(int id, ContestantDTO contestant, HttpPostedFileWrapper PhotoUrl)
        {
            try
            {
                Contestant updcontestant = unitOfWork.Contestant.Get(id);
                string previousPhotoUrl = updcontestant.PhotoUrl;
                Mapper.Map(contestant, updcontestant);
                // Verify that the user selected a file
                if (PhotoUrl != null && PhotoUrl.ContentLength > 0)
                {
                    // extract only the filename
                    var fileName = Path.GetFileName(PhotoUrl.FileName);
                    // store the file inside /Images/Photos folder
                    var path = Path.Combine(Server.MapPath("~/Images/Photos"), fileName);
                    PhotoUrl.SaveAs(path);
                    updcontestant.PhotoUrl = fileName;
                }
                else
                {
                    updcontestant.PhotoUrl = previousPhotoUrl;
                }
                unitOfWork.Contestant.Update(updcontestant);
                unitOfWork.Complete();
            }
            catch (Exception e)
            {
                TempData["Message"] = "Contestant updating failed !";
                TempData["MessageType"] = "danger";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Contestant updated successfully !";
            TempData["MessageType"] = "success";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Contestant contestant = unitOfWork.Contestant.Get(id);
                unitOfWork.Contestant.Remove(contestant);
                unitOfWork.Complete();
            }
            catch (Exception e)
            {
                TempData["Message"] = "Contestant deleting failed !";
                TempData["MessageType"] = "danger";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "Contestant deleted successfully !";
            TempData["MessageType"] = "success";
            return RedirectToAction("Index");

        }
    }
}