using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRPortal.Models
{
    public partial class Educationdetails
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string InstituteUniversity { get; set; }
        public int YearOfPass { get; set; }
        public string Comments { get; set; }

        public Employee Employee { get; set; }
    }
}
