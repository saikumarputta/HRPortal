using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly PortaldbContext _portaldbContext;
        public EmployeeRepository(PortaldbContext portaldbContext)
        {
            _portaldbContext = portaldbContext;
        }
        public bool AddEmployee(Employee employee)
        {
            _portaldbContext.Employee.Add(employee);
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            return _portaldbContext.Employee.ToList();
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}