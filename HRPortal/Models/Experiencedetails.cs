using System;
using System.Collections.Generic;

namespace HRPortal.Models
{
    public partial class Experiencedetails
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartYear { get; set; }
        public DateTime? EndYear { get; set; }
        public string Comments { get; set; }

        public Employee Employee { get; set; }
    }
}
