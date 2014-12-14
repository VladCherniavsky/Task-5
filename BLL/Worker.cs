using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class Worker
    {
        public IList<ManagerDTO>  GetAll()
        {
            List<ManagerDTO> managers = new List<ManagerDTO>();
            using (DbModelContainer db = new DbModelContainer())
            {
                var managersList = db.ManagerSet.ToList();
                foreach (var manager in managersList)
                {
                    ManagerDTO managerDTO = new ManagerDTO(manager);
                   
                    managers.Add(managerDTO);
                }
            }
            return managers;
        }

        public ManagerDTO GetOneManagerByIf(int id)
        {
            ManagerDTO managertoEdit;
            using (DbModelContainer db = new DbModelContainer())
            {
                var manager = db.ManagerSet.SingleOrDefault(x => x.Id == id);
                managertoEdit = new ManagerDTO(manager);

            }
            return managertoEdit;
        }

        public IList<ContentDTO> GetContentForOneManager(int id)
        {
            List<ContentDTO> listContentDTO;
            using (DbModelContainer db = new DbModelContainer())
            {
                var content = db.ContentSet.Where(x => x.ManagerId == id).ToList().Select(x => new ContentDTO()
                {
                  Date = x.Date,
                    Client = x.Client,
                    Item = x.Item,
                    Price = x.Price
                });
                listContentDTO = new List<ContentDTO>();
                foreach (var contentDto in content)
                {
                    listContentDTO.Add(contentDto);
                }

            }
            return listContentDTO;
        }

        public void AddContentForOneManager(ContentDTO newContent)
        {
        }
    }
}
