using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDocker.Models
{
    /// <summary>
    /// Изделие в конкретной колекции брэнда
    /// </summary>
    public class FurnitureName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CollectionId { get; set; }
    }
}
