using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace deltest
{
    class Program
    {
        static void Main(string[] args)
        {
            Car Taz = new Car()
            {
                MarkName = "ВАЗ",
                ModelName = "Priora",
                MaxSpeed = 180,
                weight = 900
            };
            Car Chevy = new Car()
            {
                MarkName="Chevrolet",
                ModelName="Rezzo",
                MaxSpeed=170,
                weight = 1400
            }; 
            Car Opel = new Car()
            {
                MarkName="Opel",
                ModelName="Astra",
                MaxSpeed=200,
                weight =1300
            };
            Car[] cars = new Car[]
            {
                Taz,
                Chevy,
                Opel
            };

            Array.Sort(cars,new CarCompere());
            foreach(var car in cars)
            {
                Console.WriteLine($"MarkName: {car.MarkName} ModelName: {car.ModelName} MaxSpeed:{car.MaxSpeed} weight: {car.weight}");
            }
        }
    }
}