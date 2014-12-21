using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ContentRepository:GenericRepository<Content>, IContentRepository
    {
        public ContentRepository(DbModelContainer dbContext) : base(dbContext)
        {
        }
    }
}
