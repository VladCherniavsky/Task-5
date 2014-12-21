using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using WebApplication3.Models;

namespace WebApplication3.repo
{
    public class myservice
    { private IWorker _worker;

        public myservice()
        {
            _worker = new Worker();
        }
        public IEnumerable listdata()
        {
            List<DataForChart> dataForCharts = new List<DataForChart>();
            var managers = _worker.GetAllManagers();
            foreach (var manager in managers)
            {

                var content = _worker.GetAllOrdersForManager(manager.Id);
                DataForChart one = new DataForChart() { ManagerName = manager.Name, AmmountOfSales = content.Count() };
                dataForCharts.Add(one);
            }
            var data = dataForCharts.AsEnumerable();
            return data;
        }
    }
}