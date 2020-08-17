using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class FurnitureNameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string CollectionName { get; set; }
        public int CollectionId { get; set; }
        public List<Product> Products { get; set; }
    }
}
