using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Specification;
using Microsoft.Owin;

namespace BLL
{
    public interface IWorker
    {
        IList<ViewManager> GetAllManagers();
        IList<ViewContent> GetAllOrdersForManager(int id);
        IList<ViewContent> GetAllContent();

        ViewContent GetOneContent(int id);
        void DeleteContent (int id);

        void UpdateContent(ViewContent viewContent);

        void AddNewInfo(ViewContent viewContent);

        IEnumerable<ViewContent> Search(SearchSpecification specification);
    } 
}
