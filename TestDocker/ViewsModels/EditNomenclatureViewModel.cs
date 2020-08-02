using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class EditNomenclatureViewModel
    {
        public List<Brand> Brands { get; set; }
        public List<Collection> Collections { get; set; }
        public List<FurnitureName> FurnitureNames { get; set; }
        public List<FurnitureType> FurnitureTypes { get; set; }
        public List<Finishing> Finishings { get; set; }
    }
}
