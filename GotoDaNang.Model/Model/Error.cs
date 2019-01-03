using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GotoDaNang.Model.Model
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int ID { set; get; }

        public string Message { get; set; }

        public string StackTrace { set; get; }

        public DateTime CreatedDate { set; get; }
    }
}