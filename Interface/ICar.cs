using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    interface ICar: IManufacture
    {
        string Name { get; set;}
        int Move(int distance);
    }
}
