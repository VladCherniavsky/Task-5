using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Content> Content { get; set; }
    }
}
