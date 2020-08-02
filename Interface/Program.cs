using System;
using System.Collections.Generic;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<ICar>();
            cars.Add(new Lada9Car());
            cars.Add(new NivaCar());
            cars.Add(new Priora());

            foreach (var car in cars)
            {
                Console.WriteLine(car.Move(1000)+ " часов пути проедет " + car.Name);
            }
            Console.ReadLine();
        }
    }
}
