using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serniaMVC.Models;
using System.Data.Entity.Core.Objects;

namespace serniaMVC.Controllers
{
    public class DevController : Controller
    {
        private serniaDBEntities db = new serniaDBEntities();

        //
        // GET: /Dev/

        public ActionResult Index(int? page = 1)
        {
            ObjectParameter totalPage = new ObjectParameter("TOTALPAGE", typeof(int));
            var pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            var datalist = db.devHistoryList(page, pageSize, totalPage);
            var list = datalist.ToList();
            ViewData["pageSize"] = pageSize;
            ViewData["totalPage"] = totalPage.Value;
            return View(list);
        }

        public ActionResult Index2(int? page = 1)
        {
            return View();
        }

        //
        // GET: /Dev/Details/5

        public ActionResult Details(int id = 0)
        {
            devHistory devhistorys = db.devHistory.Find(id);
            if (devhistorys == null)
            {
                return HttpNotFound();
            }

            return View(devhistorys);
        }
    }
}