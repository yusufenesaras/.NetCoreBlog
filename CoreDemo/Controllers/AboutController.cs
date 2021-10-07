using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var values = aboutManager.GetList();
            return View(values);
        }
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
