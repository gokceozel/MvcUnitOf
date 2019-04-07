using MvcUnitOf.Data;
using MvcUnitOf.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUnitOf.Project.Controllers
{
    public class HomeController : Controller
    {

        ICategoryService _cat;

        public HomeController(ICategoryService categoryService)
        {
            _cat = categoryService;
        }


        public ActionResult Index()
        {


            List<Category> categories = _cat.listem();

            return View(categories);
        }
    }
}