using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiji
{
    public class Eating<T>
        where T: IProduct
    {
        public int Energy { get; private set; }
        public void Add(T product)
        {
            Energy += product.Energy;
        }
    }
}
