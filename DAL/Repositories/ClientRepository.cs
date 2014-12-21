using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClientRepository:GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DbModelContainer dbContext) : base(dbContext)
        {
        }
    }
}
