using GotoDaNang.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoDaNang.Model.Model
{
    [Table("Services")]
    public class Service : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public bool? SowAllCity { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { set; get; }
    }
}
