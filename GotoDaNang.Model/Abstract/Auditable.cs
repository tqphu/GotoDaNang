using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoDaNang.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        [MaxLength(256)]
        public string Title { get; set; }

        [MaxLength(256)]
        public string Avatar { get; set; }

        [MaxLength(256)]
        public string Icon { set; get; }

        public bool Status { set; get; }
    }
}
