using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class Lada9Car : ICar
    {


     public   Lada9Car()
        {
            Name = "Девятка";
            Manufacture = "Автоваз";
        }

        public string Name { get; set ; }
        public string Manufacture { get; set ; }

        public int Move(int distance)
        {
            return distance/60;
        }
    }
}
