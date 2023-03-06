using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Interface_Generic_Constraints.Models;
namespace CS_Interface_Generic_Constraints.Database
{
    internal class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() {EmpNo=101,EmpName="Mahesh", DeptName="IT" });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR" });
            Add(new Employee() { EmpNo = 103, EmpName = "Vikram", DeptName = "AD" });
            Add(new Employee() { EmpNo = 104, EmpName = "Suprotim", DeptName = "SL" });
        }
    }
}
