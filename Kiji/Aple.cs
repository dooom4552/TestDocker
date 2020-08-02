using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiji
{
    public class Aple: IProduct
    {
        public string Name { get; set ; }
        public int Energy { get; set ; }
        public Aple()
        {
                
        }
        public Aple (string Name, int Energy)
        {
            this.Name = Name;
            this.Energy = Energy;
        }
        

    }
}
