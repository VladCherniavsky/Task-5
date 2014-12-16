using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repositories;


namespace BLL
{
    public class Worker: IWorker
    {
        IManagerRepository _managerRepository;
        

        public Worker()
        {
            _managerRepository = new MaanagerRepository(new DbModelContainer());
        }

        public IList<ViewContent> GetAll()
        {
            List<ViewContent> viewModelList = new List<ViewContent>();
            ViewContent _viewModel;
            var managers = _managerRepository.GetAll();
            foreach (var manager in managers)
            {
                _viewModel = new ViewContent();
                _viewModel.Id= manager.Id;
                _viewModel.ManagerName = manager.Name;
                viewModelList.Add(_viewModel);
            }

            return viewModelList;
        }
    }

    //    private Object _lockerForManager;
    //    public async Task<IList<ManagerDTO>>  GetAllAsync()
    //    {
    //        List<ManagerDTO> managers = new List<ManagerDTO>();
    //        using (DbModelContainer db = new DbModelContainer())
    //        {
    //            var managersList = db.ManagerSet.ToListAsync();
    //            foreach (var manager in await managersList)
    //            {
    //                ManagerDTO managerDto = new ManagerDTO(manager);
                   
    //                managers.Add(managerDto);
    //            }
    //        }
    //        return managers;
    //    }

    //    //public async Task<ManagerDTO> GetOneManagerByIdAsync(int id)
    //    //{
    //    //    ManagerDTO managertoEdit;
    //    //    using (DbModelContainer db = new DbModelContainer())
    //    //    {
    //    //        var manager = db.ManagerSet.SingleOrDefaultAsync(x => x.Id == id);
    //    //        managertoEdit =   new  ManagerDTO();
    //    //        managertoEdit.Id = manager.Id;
    //    //        managertoEdit.Name = manager.

    //    //    }
    //    //   return managertoEdit;
    //    //}

    //    public async  Task<IList<ContentDTO>> GetContentForOneManagerAsync(int id)
    //    {
    //        List<ContentDTO> listContentDTO;
    //        using (DbModelContainer db = new DbModelContainer())
    //        {
    //            var content =  (from b in db.ContentSet where b.ManagerId == id select b).ToListAsync();
    //            //db.ContentSet.Where(x => x.ManagerId == id).ToList().Select( x => new ContentDTO()
    //            //{
    //            //  Date = x.Date,
    //            //    Client = x.Client,
    //            //    Item = x.Item,
    //            //    Price = x.Price
    //            //});
    //            listContentDTO =   new List<ContentDTO>();
    //            foreach (var cont in await content)
    //            {
    //                ContentDTO contentDto = new ContentDTO();
    //                contentDto.Date = cont.Date; 
    //                contentDto.Client = cont.Client;
    //                contentDto.Item = cont.Item;
    //                contentDto.Price = cont.Price;

    //                listContentDTO.Add(contentDto);
    //            }

    //        }
    //        return listContentDTO;
    //    }

    //    public void AddContentForOneManager(ContentDTO newContent)
    //    {
    //        _lockerForManager = new object();
           
    //        Manager manager = GetOrCreateManager(newContent.Manager.Name);
    //        Client client = GetOrCreateClient(newContent.Client.Name);
    //        Item item  = GetOrCreateItem(newContent.Item.Name);
    //        AddContent(newContent,  manager,  client,  item);

    //    }

    //    protected Manager GetOrCreateManager(string managerName)
    //    {
    //        Manager manager = null;
    //        using (DbModelContainer dcModel = new DbModelContainer())
    //        {
    //            lock (_lockerForManager)
    //            {
    //                var man = dcModel.ManagerSet.FirstOrDefault(x => x.Name == managerName);
    //                if (man == null)
    //                {
    //                    var managerAdd = new Manager() { Name = managerName };
    //                    dcModel.ManagerSet.Add(managerAdd);
    //                    dcModel.SaveChanges();

    //                    var maner = dcModel.ManagerSet.FirstOrDefault(x => x.Name == managerName);
    //                    manager = new Manager() { Name = maner.Name, Id = maner.Id };
    //                }
    //                else
    //                {
    //                    manager = new Manager() { Name = man.Name, Id = man.Id };
    //                }
    //            }
    //        }
    //        return manager;
    //    }
    //    private Item GetOrCreateItem(string itemName)
    //    {
    //        Item item = null;
    //        using (DbModelContainer dcModel = new DbModelContainer())
    //        {
    //            lock (_lockerForManager)
    //            {
    //                var man = dcModel.ItemSet.FirstOrDefault(x => x.Name == itemName);
    //                if (man == null)
    //                {
    //                    item = new Item() { Name = itemName };
    //                    dcModel.ItemSet.Add(item);
    //                    dcModel.SaveChanges();

    //                    var maner = dcModel.ItemSet.FirstOrDefault(x => x.Name == itemName);
    //                    item = new Item() { Name = maner.Name, Id = maner.Id };
    //                }
    //                else
    //                {
    //                    item = new Item() { Name = man.Name, Id = man.Id };
    //                }
    //            }
    //        }
    //        return item;
    //    }

    //    private Client GetOrCreateClient(string clientName)
    //    {
    //        Client client = null;
    //        using (DbModelContainer dcModel = new DbModelContainer())
    //        {
    //            lock (_lockerForManager)
    //            {
    //                var man = dcModel.ClientSet.FirstOrDefault(x => x.Name == clientName);
    //                if (man == null)
    //                {
    //                    client = new Client() { Name= clientName };
    //                    dcModel.ClientSet.Add(client);
    //                    dcModel.SaveChanges();

    //                    var maner = dcModel.ClientSet.FirstOrDefault(x => x.Name == clientName);
    //                    client = new Client() { Name = maner.Name, Id = maner.Id };
    //                }
    //                else
    //                {
    //                    client = new Client() { Name = man.Name, Id = man.Id };
    //                }
    //            }
    //        }
    //        return client;
    //    }

       

    //    protected void AddContent(ContentDTO newContent, Manager manager, Client client, Item item)
    //    {
    //        using (var db = new DbModelContainer())
    //        {
    //            db.ContentSet.Add(new Content()
    //            {
    //                ClientId = client.Id,
    //                Client = client,
    //                Date = newContent.Date,
    //                ItemId = item.Id,
    //                Price = newContent.Price,
    //                ManagerId = manager.Id
    //            });
    //            db.SaveChanges();
    //        }
    //    }

    //}
}
