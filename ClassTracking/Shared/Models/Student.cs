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
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Mother Name")]
        public string MotherName { get; set; } = string.Empty;
        [DisplayName("Father Name")]
        public string FatherName { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public DateTime? EnrollDate { get; set; }
        [Required]
        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public ClassStandard? Class { get; set; }
    }
}
