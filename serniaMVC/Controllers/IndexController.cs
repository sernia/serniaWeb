using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serniaMVC.Models;

namespace serniaMVC.Controllers
{
    public class IndexController : Controller
    {

        //
        // GET: /Index/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }
    }
}