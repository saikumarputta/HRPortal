using System;
using System.Collections.Generic;

namespace HRPortal.Models
{
    public partial class Educationdetails
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Education { get; set; }
        public string InstituteUniversity { get; set; }
        public int YearOfPass { get; set; }
        public string Comments { get; set; }

        public Employee Employee { get; set; }
    }
}
