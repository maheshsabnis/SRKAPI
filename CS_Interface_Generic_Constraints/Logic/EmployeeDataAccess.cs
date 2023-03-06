using CS_Interface_Generic_Constraints.Database;
using CS_Interface_Generic_Constraints.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface_Generic_Constraints.Logic
{
    internal class EmployeeDataAccess : IDataAccess<Employee, int>
    {
        static Employees employees;
        public EmployeeDataAccess()
        {
            employees = new Employees();
        }

        Employee IDataAccess<Employee, int>.AddRecord(Employee record)
        {
            employees.Add(record);
            return record;
        }

        Employee IDataAccess<Employee, int>.Get(int id)
        {
            var emp = employees.Where(e=>e.EmpNo == id).FirstOrDefault();
            return emp;
        }

        IEnumerable<Employee> IDataAccess<Employee, int>.GetAll()
        {
            return employees;
        }
    }
}
