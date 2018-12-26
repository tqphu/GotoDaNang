using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoDaNang.Model.Abstract
{
    public interface IAuditable
    {
        string Title { get; set; }
        string Avatar { get; set; }
        string Icon { set; get; }
        bool Status { set; get; }
    }
}
