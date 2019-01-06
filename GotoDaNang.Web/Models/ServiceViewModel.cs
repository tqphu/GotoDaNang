using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GotoDaNang.Web.Models
{
    public class ServiceViewModel
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public bool? SowAllCity { get; set; }

        public string Title { get; set; }

        public string Avatar { get; set; }

        public string Icon { set; get; }

        public bool Status { set; get; }

        public virtual CategoryViewModel CategoryViewModel { set; get; }
    }
}