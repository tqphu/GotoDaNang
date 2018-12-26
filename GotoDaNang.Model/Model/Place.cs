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
    [Table("Places")]
    public class Place : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int ServiceID { get; set; }

        public int? ProvincesID { set; get; }

        [Column(TypeName="varchar")]
        [MaxLength(50)]
        public string Tell { get; set; }

        [Column(TypeName="varchar")]
        [MaxLength(256)]
        public string Fax { get; set; }

        [MaxLength(500)]
        public string Aderess { get; set; }

        public DateTime OpenTime { get; set; }

        public DateTime ClosingTime { get; set; }

        public int? Vote { get; set; }

        public string Website { get; set; }

        public bool? FolderSlider { get; set; }

        public bool? HomeSlider { get; set; }

        [ForeignKey("ServiceID")]
        public virtual Service Service { set; get; }

        [ForeignKey("ProvincesID")]
        public virtual Province Province  { set; get; }
    }
}
