using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class BrandCollectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FurnitureName { get; set; }
        public string FinishingName { get; set; }
        public List<FurnitureName> FurnitureNames { get; set; }
        public List<Finishing> Finishings { get; set; }
    }
}
