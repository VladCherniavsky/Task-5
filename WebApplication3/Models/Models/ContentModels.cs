using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Models
{
    public class ContentModels
    {
        public int Id { get; set; }

        public string ManagerName { get; set; }
        [Display(Name = "Client")]
        public string ClientName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Item")]
        public string ItemName { get; set; }
        [Display(Name = "Price")]
        public int Price { get; set; }
    }
}