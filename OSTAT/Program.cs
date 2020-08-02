using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSTAT
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                decimal x = Convert.ToDecimal(Console.ReadLine());

                x = Math.Floor(x);
                Console.WriteLine(x);
                //Console.ReadKey();


            }
        }
    }
}
