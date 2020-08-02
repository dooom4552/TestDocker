using System;
using System.Collections.Generic;
using System.Text;

namespace deltest
{
    class Context
    {
        Abstr strategy;
        public Context(Abstr strategy)
        {
            this.strategy = strategy;
        }
        public void ConcretMetod(string name)
        {
            strategy.Metodd(name);
        }
    }
}
