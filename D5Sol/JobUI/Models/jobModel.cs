
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JobUI.Models
{
    public class jobModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public int locationId { get; set; }

        public int departmentId { get; set; }

        public DateTime closingDate { get; set; }
    }
}
