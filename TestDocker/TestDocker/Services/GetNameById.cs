using Microsoft.AspNetCore.Identity;
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
        public static  string GetFurnitureNameNotAsync(List<FurnitureName> db, int id)
        {
            FurnitureName furnitureName =  db.FirstOrDefault(fn => fn.Id == id);
            return furnitureName.Name;
        }
        
        public static async Task<string> GetFinishingName(AllContext db, int id)
        {
            Finishing finishing = await db.Finishings.FirstOrDefaultAsync(fn => fn.Id == id);
            return finishing.Name;
        }
        
        public static string GetFinishingNameNotAsync(List<Finishing> db, int id)
        {
            Finishing finishing =  db.FirstOrDefault(fn => fn.Id == id);
            return finishing.Name;
        }

        public static async Task<string> GetFurnitureTypeName(AllContext db, int id)
        {
            FurnitureType furnitureType = await db.FurnitureTypes.FirstOrDefaultAsync(f => f.Id == id);
            return furnitureType.Name;
        } 
        
        public static  string GetFurnitureTypeNameNotAsync(List<FurnitureType> db, int id)
        {
            FurnitureType furnitureType =  db.FirstOrDefault(f => f.Id == id);
            return furnitureType.Name;
        }


        public static async Task<string> GetBrandCollectionName(AllContext db, int id)
        {
            BrandCollection brandCollection = await db.BrandCollections.FirstOrDefaultAsync(bc => bc.Id == id);
            return brandCollection.Name;
        } 
        
        public static  string GetBrandCollectionNameNotAsync(List<BrandCollection> db, int id)
        {
            BrandCollection brandCollection =  db.FirstOrDefault(bc => bc.Id == id);
            return brandCollection.Name;
        }

        public static async Task<string> GetBrandNameById(AllContext db, int id)
        {
            Brand brand = await db.Brands.FirstOrDefaultAsync(b => b.Id ==id);
            return brand.Name;
        }
        public static  string GetBrandNameByIdNotAsync(List<Brand> db, int id)
        {
            Brand brand =  db.FirstOrDefault(b => b.Id ==id);
            return brand.Name;
        }
        public static async Task<string> GetBrandNameByCollectionId(AllContext db, int id)
        {
            BrandCollection brandCollection =await  db.BrandCollections.FirstOrDefaultAsync(bc => bc.Id == id);
            Brand brand =await  db.Brands.FirstOrDefaultAsync(b => b.Id == brandCollection.BrandId);
            string name = brand.Name;
            return name;
        }

        public static async Task<string> GetUserNameById(UserManager<User> _userManager, string id)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                return user.UserName;
            }
            return default;
        }
        public static  string GetUserNameByIdNotAsync(UserManager<User> _userManager, string id)
        {
            User user =  _userManager.Users.FirstOrDefault(u => u.Id == id);
            if(user != null)
            {
                return user.UserName;
            }
            return default;
        }
    }
}
