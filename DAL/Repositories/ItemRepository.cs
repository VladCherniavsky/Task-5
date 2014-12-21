using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ItemRepository:GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(DbModelContainer dbContext) : base(dbContext)
        {
        }
    }
}
