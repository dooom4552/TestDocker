using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliNomMathWPFNet
{
    class MyMath
    {
        static public int OSTAT(int n, int d)
        {
            return (int)(n - d * Math.Floor((decimal)n / (decimal)d));
        }
    }
}
