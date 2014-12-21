using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL;
using BLL.Specification;
using WebApplication1.Models.Models;
using WebApplication3.Models.Models;

namespace WebApplication3.Controllers
{
   // [Authorize]
    public class ManagerController : Controller
    {
        private IWorker _worker;

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
            IList<ManagerModels> listOfManagers = new List<ManagerModels>();
            var managers = _worker.GetAllManagers();
            foreach (var manager in managers)
            {
                ManagerModels managerModel = new ManagerModels()
                {
                    Id = manager.Id,
                    Name = manager.Name

                };
                listOfManagers.Add(managerModel);

            }
            return View(listOfManagers);
        }

        // GET: Manager/Details/5
         [Authorize]
        public ActionResult Details(int id)
        {
            IList<ContentModels> listOfcontent = new List<ContentModels>();
            var contents = _worker.GetAllOrdersForManager(id);
            foreach (var viewContent in contents)
            {
                ContentModels contentModel = new ContentModels()
                {
                    Id = viewContent.Id,
                    ManagerName = viewContent.ManagerName,
                    ClientName = viewContent.ClientName,
                    Date = viewContent.Date.Date,
                    ItemName = viewContent.ItemName,
                    Price = viewContent.Price

                };
                listOfcontent.Add(contentModel);
            }
            return View(listOfcontent);
        }

        // GET: Manager/Create

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ClientName,ItemName,Date,Price,ManagerName")] FormCollection collection)
        {
            try
            {
                ViewContent viewContent = new ViewContent();
                viewContent.ManagerName = collection["ManagerName"];
                viewContent.ClientName = collection["ClientName"];
                viewContent.ItemName = collection["ItemName"];
                DateTime suppliedDate;
                DateTime.TryParse(collection["Date"], out suppliedDate);
                viewContent.Date = suppliedDate;
                Int32 suppliedId;
                Int32.TryParse(collection["Price"], out suppliedId);
                viewContent.Price = suppliedId;

               _worker.AddNewInfo(viewContent);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Edit/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var content = _worker.GetOneContent(id);
            ContentModels contentModel = new ContentModels()
            {
                ClientName = content.ClientName,
                Date = content.Date,
                Id = id,
                ItemName = content.ItemName,
                ManagerName = content.ManagerName,
                Price = content.Price
            };



            return View(contentModel);
        }

        // POST: Manager/Edit/5
        
        
        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ClientName,ItemName,Date,Price,Id")] FormCollection content)
        {
            try
            {
                ViewContent viewContent = new ViewContent();

                Int32 suppliedIda;
                Int32.TryParse(content["Id"], out suppliedIda);
                viewContent.Id = suppliedIda;
               
                viewContent.ClientName = content["ClientName"];
                viewContent.ItemName = content["ItemName"];
                DateTime suppliedDate;
                DateTime.TryParse(content["Date"], out suppliedDate);
                viewContent.Date = suppliedDate;

                Int32 suppliedId;
                Int32.TryParse(content["Price"], out suppliedId);
                viewContent.Price = suppliedId;

                _worker.UpdateContent(viewContent);
                return RedirectToAction("AllManagers");

                
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Manager/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Delete/5
        [HttpPost]
       // [Authorize(Roles = "Admin")]
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
          IList<ContentModels> listOfcontent = new List<ContentModels>();
            string clientName = collection["ClientName"];
            DateTime suppliedDate;
            DateTime.TryParse(collection["Date"], out suppliedDate);
            DateTime date = suppliedDate;
            string itemName = collection["Client"];
          var content=   _worker.Search(new SearchSpecification() {ClientName = clientName,Date = date, ItemName = itemName});
            foreach (var viewContent in content)
            {
                ContentModels contentModel = new ContentModels()
                {
                    Id = viewContent.Id,
                    ManagerName = viewContent.ManagerName,
                    ClientName = viewContent.ClientName,
                    Date = viewContent.Date.Date,
                    ItemName = viewContent.ItemName,
                    Price = viewContent.Price

                };
                listOfcontent.Add(contentModel);   
            }
            return View("Details",listOfcontent);
        }
    }
}
