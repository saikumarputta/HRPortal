using System;
using System.Collections.Generic;

namespace HRPortal.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Educationdetails = new HashSet<Educationdetails>();
            Employeeskills = new HashSet<Employeeskills>();
            Experiencedetails = new HashSet<Experiencedetails>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string Photo { get; set; }
        public string WebUrl { get; set; }

        public ICollection<Educationdetails> Educationdetails { get; set; }
        public ICollection<Employeeskills> Employeeskills { get; set; }
        public ICollection<Experiencedetails> Experiencedetails { get; set; }
    }
}
