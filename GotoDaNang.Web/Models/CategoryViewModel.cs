using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GotoDaNang.Web.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }

        public bool? Event { get; set; }

        public bool? Government { get; set; }

        [Required]
        public string Title { get; set; }

      
        public string Avatar { get; set; }
        
        public string Icon { set; get; }

        public bool Status { set; get; }

        public IEnumerable<CategoryViewModel> CategoryViewModels { get; set; }
    }
}