using HRPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace HRPortal.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly portaldbContext _portaldbContext;
        public EmployeeRepository(portaldbContext portaldbContext)
        {
            _portaldbContext = portaldbContext;
        }
        public bool AddEmployee(Employee employee)
        {
            _portaldbContext.Employee.Add(employee);
            _portaldbContext.SaveChanges();
            return true;
            //throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            _portaldbContext.Employee.Remove(_portaldbContext.Employee
                         .Include(emp => emp.Educationdetails)
                         .Include(emp => emp.Employeeskills)
                         .Include(emp => emp.Experiencedetails)
                         .Where(emp => emp.EmployeeId == id)
                         .FirstOrDefault());

            _portaldbContext.SaveChanges();
            return true;
            //throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            var v = _portaldbContext.Employee.Include(emp => emp.Educationdetails)
                      .Include(emp => emp.Employeeskills)
                      .Include(emp => emp.Experiencedetails)
                      .FirstOrDefault(emp => emp.EmployeeId == id);
            return v;

            // throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            var v = _portaldbContext.Employee.Include(emp => emp.Educationdetails)
                         .Include(emp => emp.Employeeskills)
                         .Include(emp => emp.Experiencedetails)
                         .ToList();
            return v;
            // throw new NotImplementedException();
        }

        public bool UpdateEmployee(int id, Employee employee)
        {
            var u = _portaldbContext.Employee
                       .Include(emp => emp.Educationdetails)
                       .Include(emp => emp.Employeeskills)
                       .Include(emp => emp.Experiencedetails)
                       .Where(emp => emp.EmployeeId == id).AsNoTracking()
                       .FirstOrDefault<Employee>(e => e.EmployeeId == id);
            u.Address = employee.Address;
            u.Email = employee.Email;
            u.FirstName = employee.FirstName;
            u.LastName = employee.LastName;
            u.OfficePhoneNumber = employee.OfficePhoneNumber;
            u.PhoneNumber = employee.PhoneNumber;
            u.Photo = employee.Photo;
            u.WebUrl = employee.WebUrl;

            u.Educationdetails = employee.Educationdetails;
            u.Employeeskills = employee.Employeeskills;
            u.Experiencedetails = employee.Experiencedetails;
             _portaldbContext.Employee.Update(u);
            _portaldbContext.SaveChanges();

           
            return true;
            //throw new NotImplementedException();

        }
    }
}