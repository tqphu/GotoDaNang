using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotoDaNang.Model.Model
{
    [Table("Provinces")]
    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        public int CityID { get; set; }

        public bool? Status { get; set; }

        [ForeignKey("CityID")]
        public virtual City City { set; get; }

        public virtual IEnumerable<Province> Provinces { set; get; }
    }
}
