using KizhiPart1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiji
{
    class Program
    {

        static void Main(string[] args)

        {
            //Aple semerinka = new Aple("Семеринка", 100);
            //Aple antonovka = new Aple("Антоновка", 120);
            //Eating<IProduct> eating = new Eating<IProduct>();
            //eating.Add(semerinka);
            //eating.Add(antonovka);
            //Console.WriteLine(eating.Energy);
            //Console.ReadKey();
            while (true)
            {
                Aple aple = new Aple();
                aple.Name = Console.ReadLine();
                aple.Energy= int.Parse(Console.ReadLine());
                Console.WriteLine($"{aple.Name} энергия {aple.Energy}");
            }

        }
    }
}
