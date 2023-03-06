using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interfaces
{
    /// <summary>
    /// ClsMath implements IMath implicitly
    /// </summary>
    internal class ClsMath : IMath, INewMath
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Subtract(int x, int y) {  return x - y; }
        public int Multiply(int x, int y) { return x * y; }
        public int Divide(int x, int y) { return x / y; }
        public double Power(double a, double b)
        {
            return Math.Pow(a, b);
        }
            
    }
}
