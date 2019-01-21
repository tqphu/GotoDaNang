using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GotoDaNang.Web.Models
{
    public class PlaceViewModel
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public int ServiceID { get; set; }

        public int? ProvincesID { set; get; }

        public string Tell { get; set; }

        public string Fax { get; set; }

        public string Aderess { get; set; }

        public DateTime? OpenTime { get; set; }

        public DateTime? ClosingTime { get; set; }

        public int? Vote { get; set; }

        public string Website { get; set; }

        public bool? FolderSlider { get; set; }

        public bool? HomeSlider { get; set; }

        public string Title { get; set; }

        public string Avatar { get; set; }

        public string Icon { set; get; }

        public bool Status { set; get; }

        public virtual ServiceViewModel ServiecViewModel { set; get; }

      
        public virtual ProvinceViewModel ProvinceViewModel { set; get; }
    }
}