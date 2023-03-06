using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface_Generic_Constraints.Models
{
    internal class Employee
    {
        public int EmpNo { get; set; }
        public string? EmpName { get; set; }
        public string? DeptName { get; set; }
    }

    internal class Person
    {
        public string? PersonId { get; set; } 
        public string? PersonName { get; set; }
    }
}
