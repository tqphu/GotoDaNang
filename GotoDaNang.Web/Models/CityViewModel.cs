using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GotoDaNang.Web.Models
{
    public class CityViewModel
    {
      
        public int ID { get; set; }

        public string Name { get; set; }

        public bool? Status { get; set; }

        public virtual IEnumerable<CityViewModel> CityViewModels { set; get; }
    }
}