using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL.Specification;
using DAL;
using DAL.Repositories;
using Microsoft.Owin;


namespace BLL
{
    public class Worker: IWorker
    {
        private IManagerRepository _managerRepository;
        private IContentRepository _contentRepository;
        private IClientRepository _clientRepository;
        private IItemRepository _itemRepository;

        

        public Worker()
        {
            _managerRepository = new MaanagerRepository(new DbModelContainer());
            _clientRepository = new ClientRepository(new DbModelContainer());
            _itemRepository = new ItemRepository(new DbModelContainer());
            _contentRepository = new ContentRepository(new DbModelContainer());
        }

        public IList<ViewManager> GetAllManagers()
        {
            var managers = _managerRepository.GetAll();

            return managers.Select(manager => manager.ToViewManager()).ToList();
        }

       

        public IList<ViewContent> GetAllOrdersForManager(int id)
        {
            var contents = _contentRepository.GetList(x => x.ManagerId == id);

            return contents.Select(content => content.ToViewContent()).ToList();
        }
        

        public ViewContent GetOneContent(int id)
        {

            return _contentRepository.GetSingle(x => x.Id == id).ToViewContent(); 
        }

        public void DeleteContent(int id)
        {
            var content = _contentRepository.GetSingle(x => x.Id == id);
            _contentRepository.Delete(content.Id);
        }


        public void UpdateContent(ViewContent viewContent)
        {
           
            var contentToEdit = _contentRepository.GetSingle(x => x.Id == viewContent.Id);
            _clientRepository.Update(new Client()
            {
                Id = contentToEdit.ClientId,
                Name = viewContent.ClientName
            });
           
            _itemRepository.Update(new Item()
            {
                Id = contentToEdit.ItemId,
                Name = viewContent.ItemName
                
            });
            contentToEdit.Date = viewContent.Date;          
            contentToEdit.Price = Convert.ToString(viewContent.Price);
            _contentRepository.Update(contentToEdit);
        }

        public void AddNewInfo(ViewContent viewContent)
        {
            var manager = _managerRepository.GetSingle(x => x.Name == viewContent.ManagerName);
            Content content = new Content();
            if (manager == null)
            {
                _managerRepository.Add(new Manager(){Name = viewContent.ManagerName});
                var newManager = _managerRepository.GetSingle(x => x.Name == viewContent.ManagerName);
                content.ManagerId = newManager.Id;
            }
            else
            {
                content.ManagerId = manager.Id;
            }

            var client = _clientRepository.GetSingle(x => x.Name == viewContent.ClientName);
            if (client == null)
            {
                _clientRepository.Add(new Client(){Name = viewContent.ClientName});
                var newClient = _clientRepository.GetSingle(x => x.Name == viewContent.ClientName);
                content.ClientId = newClient.Id;
            }
            else
            {
                content.ClientId = client.Id;
            }
            var item = _itemRepository.GetSingle(x => x.Name == viewContent.ItemName);
            if (item == null)
            {
                _itemRepository.Add(new Item(){Name = viewContent.ItemName});
                var newItem = _itemRepository.GetSingle(x => x.Name == viewContent.ItemName);
                content.ItemId = newItem.Id;
            }
            else
            {
                content.ItemId = item.Id;
            }
            content.Date = viewContent.Date;
            content.Price = Convert.ToString(viewContent.Price);
            _contentRepository.Add(content);

        }

        public IList<ViewContent> GetAllContent()
        {
            var contents = _contentRepository.GetAll();
            return contents.Select(content => content.ToViewContent()).ToList();
        }

        public IEnumerable<ViewContent> Search(SearchSpecification specification)
        {
            return specification.SatisfiedBy(GetAllContent());
        }
    }



    public static class ExtensionsMethod
    {
        public static ViewManager ToViewManager(this Manager manager)
        {
            return new ViewManager()
            {
                Id= manager.Id,
                Name = manager.Name
            };
        }

        public static ViewContent ToViewContent(this Content content)
        {
            return  new ViewContent()
            {
                Id = content.Id,
                ManagerName = content.Manager.Name,
                ClientName = content.Client.Name,
                Date = content.Date,
                ItemName = content.Item.Name,
                Price = Convert.ToInt32(content.Price)
            };
        }
    }
}
