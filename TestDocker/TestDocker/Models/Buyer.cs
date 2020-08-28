using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.interfaces;

namespace TestDocker.Models
{
    /// <summary>
    /// покупатель
    /// </summary>
    public class Buyer : INameId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
