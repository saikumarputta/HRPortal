using System;
using System.Collections.Generic;

namespace HRPortal.Models
{
    public partial class Employeeskills
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeSkill { get; set; }
        public int SkillRating { get; set; }
        public string Comments { get; set; }

        public Employee Employee { get; set; }
    }
}
