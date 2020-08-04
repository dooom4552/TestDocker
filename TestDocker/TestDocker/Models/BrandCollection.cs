using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDocker.Models
{
    /// <summary>
    /// коллекция в брэнде
    /// </summary>
    public class BrandCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}
