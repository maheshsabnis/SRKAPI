using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface_Generic_Constraints.Logic
{
    /// <summary>
    /// The Generic interface which will have generic methods
    /// but the type patameter i.e. TEntity will always be of the type 'class'
    /// THe 'in' means the 'TPk' will always be an input parameter
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal interface IDataAccess<TEntity, in TPk> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TPk id);
        TEntity AddRecord(TEntity record);
    }
}
