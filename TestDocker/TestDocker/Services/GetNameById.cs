using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Data;
using TestDocker.Models;

namespace TestDocker.Services
{
    static public class GetNameById
    {
        public static async Task<string> GetFurnitureName(AllContext db, int id)
        {
            FurnitureName furnitureName = await db.FurnitureNames.FirstOrDefaultAsync(fn => fn.Id == id);
            return furnitureName.Name;
        }
        
        public static async Task<string> GetFinishingName(AllContext db, int id)
        {
            Finishing finishing = await db.Finishings.FirstOrDefaultAsync(fn => fn.Id == id);
            return finishing.Name;
        }


        public static async Task<string> GetBrandCollectionName(AllContext db, int id)
        {
            BrandCollection brandCollection = await db.BrandCollections.FirstOrDefaultAsync(bc => bc.Id == id);
            return brandCollection.Name;
        }
        public static async Task<string> GetBrandNameByCollectionId(AllContext db, int id)
        {
            BrandCollection brandCollection = await db.BrandCollections.FirstOrDefaultAsync(bc => bc.Id == id);
            Brand brand = await db.Brands.FirstOrDefaultAsync(b => b.Id == brandCollection.BrandId);
            return brand.Name;
        }
    }
}
