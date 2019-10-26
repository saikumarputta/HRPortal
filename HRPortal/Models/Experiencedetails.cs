using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRPortal.Models
{
    public partial class Experiencedetails
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public DateTime StartYear { get; set; }
        public DateTime? EndYear { get; set; }

        public Employee Employee { get; set; }
    }
}
