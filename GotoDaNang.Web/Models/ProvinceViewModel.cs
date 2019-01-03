using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GotoDaNang.Web.Models
{
    public class ProvinceViewModel
    {
       
        public int ID { get; set; }

      
        public string Name { get; set; }

        public int CityID { get; set; }

        public bool? Status { get; set; }

       
        public virtual CityViewModel CityViewModel { set; get; }

        public virtual IEnumerable<ProvinceViewModel> ProvinceViewModels { set; get; }
    }
}