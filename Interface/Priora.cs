using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class Priora : ICar   
    {
       public Priora()
        {
            Name = "Приора";
            Manufacture = "Автоваз";
        }
        public string Name { get; set ; }
        public string Manufacture { get ; set ;}

        public int Move(int distance)
        {
            return distance/80;
        }
    }
}
