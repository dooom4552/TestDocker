using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class BuyerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductOut> ProductOuts { get; set; }
    }
}
