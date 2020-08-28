using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.interfaces;

namespace TestDocker.Models
{
    /// <summary>
    /// отделка
    /// </summary>
    public class Finishing : INameId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CollectionId { get; set; }
    }
}
