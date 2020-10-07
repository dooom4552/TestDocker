using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace deltest
{
    class CarCompere : IComparer<Car>
    {
        public int Compare( Car x, Car y)
        {
            if (x.weight > y.weight)
            {
                return 1;
            }
            else if (x.weight < y.weight)
            {
                return -1;
            }
            else
                return 0;
                
        }
    }
}
