﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class EditNomenclatureViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int BrandCollectionId { get; set; }
        public List<Brand> Brands { get; set; }
        
        public List<BrandCollectionBrandNameViewModel> BrandCollectionBrandNameViewModels { get; set; }
        public List<FurnitureName> FurnitureNames { get; set; }
        public List<FurnitureType> FurnitureTypes { get; set; }
        public List<Finishing> Finishings { get; set; }
        public List<Buyer> Buyers { get; set; }       
        public string BrandCollectionName { get; set; } 
        public string FinishingName { get; set; }
        public string FurName { get; set; } 
    } 
}
