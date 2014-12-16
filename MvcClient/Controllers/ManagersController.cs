using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using MvcClient.Models;

namespace MvcClient.Controllers
{
    public class ManagersController : Controller
    {
          private IWorker _worker;

        public ManagersController()
        {
            _worker = new Worker();
        }
        //
        // GET: /Managers/

        public ActionResult Index()
        {
            IList<ManagerModel> listOfManagers = new List<ManagerModel>(); ;
            var managers = _worker.GetAll();
            foreach (var manager in managers)
            {
                ManagerModel managerModel = new ManagerModel()
                {
                    Id = manager.Id,
                    Name = manager.ManagerName
                };
                listOfManagers.Add(managerModel);

            }
            return View(listOfManagers);
           
        }

    }
}
