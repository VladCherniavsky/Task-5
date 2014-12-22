using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL;
using BLL.Specification;
using WebApplication1.Models.Models;
using WebApplication3.Models.Models;

namespace WebApplication3.Controllers
{
    
    public class ManagerController : Controller
    {
        private readonly IWorker _worker;

        public ManagerController()
        {
            _worker = new Worker();
        }
        // GET: Manager
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

       [Authorize]
        public ActionResult AllManagers()
        {
           var managers = _worker.GetAllManagers();
           IList<ManagerModels> listOfManagers = managers.Select(manager => new ManagerModels()
           {
               Id = manager.Id, Name = manager.Name
           }).ToList();
           return View(listOfManagers);
        }

        // GET: Manager/Details/5
         [Authorize]
        public ActionResult Details(int id)
        {
             var contents = _worker.GetAllOrdersForManager(id);
             IList<ContentModels> listOfcontent = contents.Select(viewContent => viewContent.ToContentModels()).ToList();
             return View(listOfcontent);
        }

        // GET: Manager/Create

       // [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind(Include = "ClientName,ItemName,Date,Price,ManagerName")] FormCollection collection)
        {
            try
            {
                _worker.AddNewInfo(new ViewContent()
               {
                   ManagerName = collection["ManagerName"],
                   ClientName = collection["ClientName"],
                   ItemName = collection["ItemName"],
                   Date = Convert.ToDateTime(collection["Date"]),
                   Price = Convert.ToInt32(collection["Price"])
                   
               });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Edit/5
        //[Authorize(Roles = "Admin")]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var content = _worker.GetOneContent(id);
            return View(content.ToContentModels());
        }

        // POST: Manager/Edit/5
        
        
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ClientName,ItemName,Date,Price,Id")] FormCollection content)
        {
            try
            {
                _worker.UpdateContent(new ViewContent()
                {
                    Id = Convert.ToInt32(content["Id"]),
                    ClientName = content["ClientName"],
                    ItemName = content["ItemName"],
                    Date = Convert.ToDateTime(content["Date"]),
                    Price = Convert.ToInt32(content["Price"])
                });
                return RedirectToAction("AllManagers");

                
            }
            catch(Exception e)
            {
                return View();
            }
        }

       
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _worker.DeleteContent(id);
                return RedirectToAction("");

                
            }
            catch
            {
                return View();
            }
        }


        [Authorize]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ViewResult Search( FormCollection collection)
        {
            DateTime suppliedDate;
            DateTime.TryParse(collection["Date"], out suppliedDate);
            DateTime date = suppliedDate;
           
            var content=   _worker.Search(new SearchSpecification()
            {
                ClientName = collection["ClientName"],
                Date = date, 
                ItemName = collection["ItemName"],
                ManagerName = collection["ManagerName"]
            });

            IList<ContentModels> listOfcontent = content.Select(viewContent => viewContent.ToContentModels()).ToList();
            return View("Details",listOfcontent);
        }
    }

    public static class ExtensionsMethod
    {
        public static ContentModels ToContentModels(this ViewContent viewContent)
        {
            return new ContentModels()
            {
                Id = viewContent.Id,
                ManagerName = viewContent.ManagerName,
                ClientName = viewContent.ClientName,
                Date = viewContent.Date.Date,
                ItemName = viewContent.ItemName,
                Price = viewContent.Price
            };
        }
    }
}
