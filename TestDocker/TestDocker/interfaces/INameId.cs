using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDocker.interfaces
{
   public  interface INameId
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
