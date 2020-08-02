using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class NivaCar : ICar, IOfroadCar
    {

       public NivaCar()
        {
            Name = "Нива";
            Manufacture = "Автоваз";
        }

        public string Name { get ; set ; }
        public string MuftaType { get ; set ; }
        public string Manufacture { get; set ; }

        public int Move(int distance)
        {
            return distance/20;
        }
    }
}
