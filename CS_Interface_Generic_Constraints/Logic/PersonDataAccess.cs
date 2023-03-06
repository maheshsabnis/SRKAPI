using CS_Interface_Generic_Constraints.Database;
using CS_Interface_Generic_Constraints.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface_Generic_Constraints.Logic
{
    internal class PersonDataAccess : IDataAccess<Person, string>
    {
        static Persons persons;

        public PersonDataAccess()
        {
            persons = new Persons ();
        }

        Person IDataAccess<Person, string>.AddRecord(Person record)
        {
            persons.Add (record);
            return record;
        }

        Person IDataAccess<Person, string>.Get(string id)
        {
           var per = persons.Where(p=>p.PersonId == id).FirstOrDefault();
            return per;
        }

        IEnumerable<Person> IDataAccess<Person, string>.GetAll()
        {
            return persons;
        }
    }
}
