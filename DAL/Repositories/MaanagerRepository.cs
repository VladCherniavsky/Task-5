using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MaanagerRepository: GenericRepository<Manager>, IManagerRepository
    {
        public MaanagerRepository(DbModelContainer dbContext) : base(dbContext)
        {
        }
    }
}
