using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPortal.Repository
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();
        Employee GetById(int id);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(int id, Employee employee);
        bool DeleteEmployee(int id);
    }
}
