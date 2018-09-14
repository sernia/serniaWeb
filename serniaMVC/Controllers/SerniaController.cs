using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace serniaMVC.Controllers
{
    public class SerniaController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            serniaGlobal.setCountry();
            base.Initialize(requestContext);
        }

        //
        // GET: /Sernia/

        public ActionResult Index()
        {
            return View();
        }

    }
}
