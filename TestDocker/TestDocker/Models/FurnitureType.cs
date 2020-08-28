using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.interfaces;

namespace TestDocker.Models
{
    /// <summary>
    /// какой тип изделия стол стул, кровать
    /// </summary>
    public class FurnitureType : INameId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
