using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class ContentDTO
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Date { get; set; }
        public string Price { get; set; }
        public int ManagerId { get; set; }
        public int ClientId { get; set; }
        public int ItemId { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual Client Client { get; set; }
        public virtual Item Item { get; set; }
    }
}
