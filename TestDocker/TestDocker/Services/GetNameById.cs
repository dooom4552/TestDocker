using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Data;
using TestDocker.interfaces;
using TestDocker.Models;

namespace TestDocker.Services
{
    static public class GetNameById
    {                       
        public static async Task<string> GetBrandNameByCollectionId(AllContext db, int id)
        {
            BrandCollection brandCollection =await  db.BrandCollections.FirstOrDefaultAsync(bc => bc.Id == id);
            Brand brand =await  db.Brands.FirstOrDefaultAsync(b => b.Id == brandCollection.BrandId);
            string name = brand.Name;
            return name;
        }

    }
}
