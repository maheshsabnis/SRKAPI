using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface_Generic
{
    /// <summary>
    /// The interace is generic, the T can be any valid .NET type
    /// e.g. int, string, double, object, etc.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IOperation<T> 
    {
        // THe Generic Method with generic input and output parameter 
        T Add(T a, T b);
    }

    public class ClsIntOperation : IOperation<int>
    {
        int IOperation<int>.Add(int a, int b)
        {
            return a + b; // INteger Addition 
        }
    }

    public class ClsStringOperation : IOperation<string>
    {
        string IOperation<string>.Add(string a, string b)
        {
            return a + b; // String Conatenation
        }
    }
}
