using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Models
{
    public class ManagerModels
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Second Name")]
        public string Name { get; set; }
    }
}