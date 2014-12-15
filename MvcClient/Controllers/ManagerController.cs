using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;

namespace MvcClient.Controllers
{
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/

        public async Task<ActionResult> Index()
        {
            Worker worker = new Worker();
            var managers = await  worker.GetAllAsync();
            return View(managers);
        }

        //
        // GET: /Manager/Edit/
        //public ActionResult Edit( int id)
        //{
        //    Worker worker = new Worker();
        //    var manager = worker.GetOneManagerByIf(id);
        //    return View(manager);
        //}

        public async Task<ActionResult> Details(int id) 
        {
            Worker worker = new Worker();
            var contents = await worker.GetContentForOneManagerAsync(id);
            return View(contents);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContentDTO newContent)
        {

            if (ModelState.IsValid)
            {
                Worker worker = new Worker();
                worker.AddContentForOneManager(newContent);

                return RedirectToAction("Index");
            }
            else
            {
                return View(newContent);
            }
        }





    }
}
