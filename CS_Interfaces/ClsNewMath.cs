using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interfaces
{
    /// <summary>
    /// Expliit IMplmentation
    /// </summary>
    internal class ClsNewMath : IMath, INewMath
    {
        int IMath.Add(int x, int y) { return x + y; }
        int IMath.Subtract(int x, int y) { return x - y; }
        int IMath.Divide(int x, int y) { return x / y; }
        int IMath.Multiply(int x, int y) {return x* y; }

        int INewMath.Add(int x, int y)
        {
            return (x*x) + 2*x*y + (y*y);
        }

        int INewMath.Subtract(int x, int y)
        {
            return (x * x) - 2 * x * y + (y * y);
        }

        int INewMath.Multiply(int x, int y)
        {
            return (x * x) * 2 * x * y * (y * y);
        }

        int INewMath.Divide(int x, int y)
        {
            return (x * x) / (2 * x * y) / (y * y);
        }
    }
}
