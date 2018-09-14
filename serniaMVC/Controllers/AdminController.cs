using serniaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Runtime.Caching;

namespace serniaMVC.Controllers
{
    [ValidateInput(false)]
    public class AdminController : Controller
    {
        private serniaDBEntities db = new serniaDBEntities();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult serniaHistoryCreate()
        {
            return View();
        }

        /// <summary>
        /// 講座作成/更新
        /// </summary>
        /// <returns></returns>
        public ActionResult devCreate(int id = 0)
        {
            var devInfo = db.devHistory.Find(id);
            var dbDevHistoryList = db.devHistory.GroupBy(d => d.category);
            List<SelectListItem> ddList = dbDevHistoryList.Select(d => new SelectListItem { Text = d.Key, Value = d.Key }).ToList();
            //ddList.Insert(0, new SelectListItem() { Value = string.Empty, Text = string.Empty, Selected = true });
            ViewBag.category = new SelectList(ddList, "Value", "Text", devInfo == null ? string.Empty : devInfo.category);

            //devInfoがNULLの場合、モデルを初期化する
            if (devInfo == null) devInfo = new devHistory() { idx = 0 };
            return View(devInfo);
        }

        /// <summary>
        /// 講座登録イベント
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult devCreate(devHistory j, FormCollection fc)
        {
            if (!ModelState.IsValid) return View();

            if (Convert.ToBoolean(fc["categoryCheck"].Split(',')[0]))
                j.category = fc["category_empty"].ToString();

            j.createdate = DateTime.Now;
            db.devHistory.Add(j);
            if (j.idx > 0) db.Entry(j).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult serniaHistoryCreate(serniaHistory j)
        {
            if (ModelState.IsValid)
            {
                j.createdate = DateTime.Now;
                db.serniaHistory.Add(j);
                db.SaveChanges();
            }
            else
            {
                return View();
            }
            return RedirectToAction("index");
        }

        public ActionResult japaneseIndex()
        {
            var japaneseList = from o in db.japaneseHistory select o;
            return View(japaneseList);
        }

        /// <summary>
        /// 日本語詳細
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult japaneseDetail(int id = 0)
        {

            ObjectCache cache = MemoryCache.Default;
            List<japaneseMemo> memo = new List<japaneseMemo>();
            memo = cache["memo"] as List<japaneseMemo>;
            if (memo == null)
            {
                CacheItemPolicy cip = new CacheItemPolicy();
                cip.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
                memo = (from o in db.japaneseMemo select o).ToList();
                cache.Set("memo", memo, cip);
            }

            japaneseHistory details = db.japaneseHistory.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }

            ViewData["memo"] = memo;
            return View(details);
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult japaneseCreate()
        {
            ViewData["memo"] = from o in db.japaneseMemo select o;
            return View();
        }

        public ActionResult japaneseHistoryCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult japaneseHistoryCreate(japaneseHistory j)
        {
            if (ModelState.IsValid)
            {
                db.japaneseHistory.Add(j);
                db.SaveChanges();
                var idx = db.japaneseHistory.Max(model => model.idx);
                return RedirectToAction("japanesedetail/" + idx);
            }

            return View();
        }

        [HttpPost]
        public ActionResult japaneseCreate(japaneseMemo j)
        {
            if (ModelState.IsValid)
            {
                db.japaneseMemo.Add(j);
                db.SaveChanges();
            }
            return RedirectToAction("japanesecreate");
        }

        public ActionResult devEdit(int id = 0)
        {
            devHistory devhistorys = db.devHistory.Find(id);
            if (devhistorys == null)
            {
                return HttpNotFound();
            }
            return View(devhistorys);
        }

        [HttpPost]
        public ActionResult devEdit(devHistory j)
        {
            if (ModelState.IsValid)
            {
                db.Entry(j).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                return View(j);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Login(string id, string password)
        {
            if (id.Equals("sernia") && password.Equals("wlduddk1"))
            {
                FormsAuthentication.SetAuthCookie(id, false);
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// 日本語単語一覧
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult japaneseList(int id = 0)
        {
            var memo = from o in db.japaneseMemo select o;
            ViewData["memo"] = memo;
            return View();
        }

        [HttpPost]
        public ActionResult japaneseList(string url, int count = 0)
        {
            if (string.IsNullOrEmpty(url) && count == 0)
            {
                return View();
            }

            var memo = from o in db.japaneseMemo select o;
            ViewData["memo"] = memo;
            return View();
        }


        /// <summary>
        /// Viewイベントの後、実装される
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!User.Identity.IsAuthenticated && !filterContext.RouteData.Values["action"].Equals("login"))
            {
                filterContext.Result = new RedirectResult("/admin/login");
                return;
            }

            base.OnActionExecuted(filterContext);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
