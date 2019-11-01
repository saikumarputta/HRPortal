using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPortal.Models;

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
            _portaldbContext.employees.Add(employee);
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
            return _portaldbContext.employees.ToList();
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}