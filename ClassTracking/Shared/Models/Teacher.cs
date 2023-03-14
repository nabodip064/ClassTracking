using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Shared.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty; 
        [Required]
        public string Designation { get; set; } = string.Empty;
        [DisplayName("Joining Date")]
        public DateTime? JoiningDate { get; set; }
        public int? ClassId { get; set; }
    }
}
