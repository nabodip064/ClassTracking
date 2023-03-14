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
    public class ClassStandard
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Standard { get; set; }
        [Required, Range(1,60)]
        public int MaxStudent { get; set; }
        [Required]
        [DisplayName("Session Year")]
        public int SessionYear { get; set; }
        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }
        [NotMapped]
        public int? TotalStudent { get; set; }
    }
}
