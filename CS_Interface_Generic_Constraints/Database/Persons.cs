using CS_Interface_Generic_Constraints.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface_Generic_Constraints.Database
{
    internal class Persons: List<Person>
    {
        public Persons()
        {
            Add(new Person() { PersonId="Per-001", PersonName="Indiana Jones"});
            Add(new Person() { PersonId = "Per-007", PersonName = "James Bond" });
        }
    }
}
