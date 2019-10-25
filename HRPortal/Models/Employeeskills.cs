using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRPortal.Models
{
    public partial class Employeeskills
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeSkill { get; set; }
        [Required]
        [Range(1,5)]
        public int SkillRating { get; set; }
        public string Comments { get; set; }

        public Employee Employee { get; set; }
    }
}
