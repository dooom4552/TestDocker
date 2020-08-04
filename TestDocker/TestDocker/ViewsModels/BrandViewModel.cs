using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandCollectionName { get; set; }
        public List<BrandCollection> BrandCollections { get; set; }
    }
}
