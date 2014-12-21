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
            List<ViewManager> viewModelList = new List<ViewManager>();
            ViewManager _viewModel;
            var managers = _managerRepository.GetAll();
            foreach (var manager in managers)
            {
                _viewModel = new ViewManager();
                _viewModel.Id= manager.Id;
                _viewModel.Name = manager.Name;
                viewModelList.Add(_viewModel);
            }

            return viewModelList;
        }

       

        public IList<ViewContent> GetAllOrdersForManager(int? id)
        {
            IList<ViewContent> viewContents = new List<ViewContent>();
            ViewContent _viewContent;
            var contents = _contentRepository.GetList(x => x.ManagerId == id);
            foreach (var content in contents)
            {
                
                _viewContent = new ViewContent();
                _viewContent.Id = content.Id;
                _viewContent.ManagerName = content.Manager.Name;
                _viewContent.ClientName = content.Client.Name;
                _viewContent.Date = content.Date;
                _viewContent.ItemName = content.Item.Name;
                _viewContent.Price = Convert.ToInt32(content.Price);

                viewContents.Add(_viewContent);
            }
            return viewContents;
        }
        

        public ViewContent GetOneContent(int? id)
        {
            var content = _contentRepository.GetSingle(x => x.Id == id);
            ViewContent viewContent = new ViewContent()
            {
                //Id = content.Id,
                ClientName = content.Client.Name,
                ItemName = content.Item.Name,
                Date = content.Date,
                Price = Convert.ToInt32(content.Price)
            };
            return viewContent;


        }

        public void DeleteContent(int? id)
        {
            var content = _contentRepository.GetSingle(x => x.Id == id);
            _contentRepository.Delete(content.Id);
        }


        public void UpdateContent(ViewContent viewContent)
        {
           
            var contentToEdit = _contentRepository.GetSingle(x => x.Id == viewContent.Id);
            Client client = new Client();
            client.Id = contentToEdit.ClientId;
            client.Name = viewContent.ClientName;

            _clientRepository.Update(client);

            Item item = new Item();
            item.Id = contentToEdit.ItemId;
            item.Name = viewContent.ItemName;
            _itemRepository.Update(item);

          
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
            IList<ViewContent> viewContents = new List<ViewContent>();
            ViewContent _viewContent;
            var contents = _contentRepository.GetAll();
            foreach (var content in contents)
            {

                _viewContent = new ViewContent();
                _viewContent.Id = content.Id;
                _viewContent.ManagerName = content.Manager.Name;
                _viewContent.ClientName = content.Client.Name;
                _viewContent.Date = content.Date;
                _viewContent.ItemName = content.Item.Name;
                _viewContent.Price = Convert.ToInt32(content.Price);

                viewContents.Add(_viewContent);
            }
            return viewContents;
        }

        public IEnumerable<ViewContent> Search(SearchSpecification specification)
        {
            return specification.SatisfiedBy(GetAllContent());
        }
    }

   
    
   
}
