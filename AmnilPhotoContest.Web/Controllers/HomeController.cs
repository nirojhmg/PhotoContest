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
    public class HomeController : Controller
    {
        IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}