using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services;
using BLL;
using WebApplication3.Models;
using WebApplication3.repo;

namespace WebApplication3.Controllers
{
    public class ChartController : Controller
    {
         private IWorker _worker;

        public ChartController()
        {
            _worker = new Worker();
        }
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        [WebMethod]
        public JsonResult PieChart()
        {
            myservice asd = new myservice();
            var data = asd.listdata();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}