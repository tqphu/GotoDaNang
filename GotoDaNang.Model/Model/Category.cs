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
    [Table("Categories")]
    public class Category  : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public bool? Event { get; set; }

        public bool? Government { get; set; }

        public IEnumerable<Category> categories { get; set; }
    }
}
