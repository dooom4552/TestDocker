using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDocker.Data;
using TestDocker.Models;
using TestDocker.ViewsModels;

namespace TestDocker.Controllers
{
    [Authorize(Roles = "director")]
    public class AnalyticsController : Controller
    {
        readonly UserManager<User> _userManager;

        private readonly AllContext db;
        public AnalyticsController(AllContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Analytics()
        {
            List<Product> products = await db.Products.ToListAsync();
            List<ProductOut> productOuts = await db.ProductOuts.ToListAsync();
            List<Brand> brands = await db.Brands.ToListAsync();
            List<BrandCollection> brandCollections = await db.BrandCollections.ToListAsync();
            List<FurnitureName> furnitureNames = await db.FurnitureNames.ToListAsync();
            List<Finishing> finishings = await db.Finishings.ToListAsync();
            List<FurnitureType> furnitureTypes = await db.FurnitureTypes.ToListAsync();
            List<ProductSold> productSolds = await db.ProductSolds.ToListAsync();
            List<Buyer> buyers = await db.Buyers.ToListAsync();

            List<ProductSoldVM> productSoldVMs = (from ps in productSolds
                                  select new ProductSoldVM
                                  {
                                      Id = ps.Id,
                                      ProductId = ps.ProductId,
                                      ProductOutId = ps.ProductOutId,
                                      Amountsold = ps.Amountsold,
                                      BrandId = products.FirstOrDefault(p => p.Id == ps.ProductId).BrandId,
                                      CollectionId = products.FirstOrDefault(p => p.Id == ps.ProductId).CollectionId,
                                      FurnitureNameId = products.FirstOrDefault(p => p.Id == ps.ProductId).FurnitureNameId,
                                      FinishingId = products.FirstOrDefault(p => p.Id == ps.ProductId).FinishingId,
                                      FurnitureTypeId = products.FirstOrDefault(p => p.Id == ps.ProductId).FurnitureTypeId,
                                      Brand = brands.FirstOrDefault(b => b.Id == products.FirstOrDefault(p => p.Id == ps.ProductId).BrandId).Name,
                                      BrandCollection = brandCollections.FirstOrDefault(b => b.Id == products.FirstOrDefault(p => p.Id == ps.ProductId).CollectionId).Name,
                                      FurnitureName = furnitureNames.FirstOrDefault(b => b.Id == products.FirstOrDefault(p => p.Id == ps.ProductId).FurnitureNameId).Name,
                                      Finishing = finishings.FirstOrDefault(b => b.Id == products.FirstOrDefault(p => p.Id == ps.ProductId).FinishingId).Name,
                                      FurnitureType = furnitureTypes.FirstOrDefault(b => b.Id == products.FirstOrDefault(p => p.Id == ps.ProductId).FurnitureTypeId).Name,
                                      ComePrice = products.FirstOrDefault(p => p.Id == ps.ProductId).ComePrice,
                                      ComeSumPrice = ps.Amountsold * products.FirstOrDefault(p => p.Id == ps.ProductId).ComePrice,
                                      GiveOutPrice = productOuts.FirstOrDefault(po => po.Id == ps.ProductOutId).GiveOutPrice,
                                      GiveOutSumPrice = ps.Amountsold * productOuts.FirstOrDefault(po => po.Id == ps.ProductOutId).GiveOutPrice,
                                      ComeDataTime = products.FirstOrDefault(p => p.Id == ps.ProductId).ComeDataTime,
                                      GiveOutDataTime = productOuts.FirstOrDefault(po => po.Id == ps.ProductOutId).GiveOutDataTime,
                                      BuyerId = productOuts.FirstOrDefault(po => po.Id == ps.ProductOutId).BuyerNameId,
                                      BuyerName = buyers.FirstOrDefault(b => b.Id == productOuts.FirstOrDefault(po => po.Id == ps.ProductOutId).BuyerNameId).Name
                                  }).ToList();
            return View(productSoldVMs);
        }

        [HttpPost]
        public async Task<IActionResult> Analytics(DateTime fitstdateTime, DateTime seconddateTime)
        {
            List<Product> products = await db.Products.ToListAsync();
            List<ProductOut> productOuts = await db.ProductOuts.ToListAsync();
            List<Brand> brands = await db.Brands.ToListAsync();
            List<BrandCollection> brandCollections = await db.BrandCollections.ToListAsync();
            List<FurnitureName> furnitureNames = await db.FurnitureNames.ToListAsync();
            List<Finishing> finishings = await db.Finishings.ToListAsync();
            List<FurnitureType> furnitureTypes = await db.FurnitureTypes.ToListAsync();
            List<ProductSold> productSolds = await db.ProductSolds.ToListAsync();

            List<Buyer> buyers = await db.Buyers.ToListAsync();

            List<ProductSoldVM> productSoldVMs = (from ps in productSolds
                                                  select new ProductSoldVM
                                                  {
                                                      Id = ps.Id,
                                                      ProductId = ps.ProductId,
                                                      ProductOutId = ps.ProductOutId,
                                                      Amountsold = ps.Amountsold,
                                                      BrandId = products.FirstOrDefault(p => p.Id == ps.ProductId).BrandId,
                                                      CollectionId = products.FirstOrDefault(p => p.Id == ps.ProductId).CollectionId,
                                                      FurnitureNameId = products.FirstOrDefault(p => p.Id == ps.ProductId).FurnitureNameId,
                                                      FinishingId = products.FirstOrDefault(p => p.Id == ps.ProductId).FinishingId,
                                                      FurnitureTypeId = products.FirstOrDefault(p => p.Id == ps.ProductId).FurnitureTypeId,
                                                      Brand = brands.FirstOrDefault(b => b.Id == products.FirstOrDefault(p => p.Id == ps.ProductId).BrandId).Name,
                                                      BrandCollection = brandCollections.FirstOrDefault(b => b.Id == products.FirstOrDefault(p => p.Id == ps.ProductId).CollectionId).Name,
                                                      FurnitureName = furnitureNames.FirstOrDefault(b => b.Id == products.FirstOrDefault(p => p.Id == ps.ProductId).FurnitureNameId).Name,
                                                      Finishing = finishings.FirstOrDefault(b => b.Id == products.FirstOrDefault(p => p.Id == ps.ProductId).FinishingId).Name,
                                                      FurnitureType = furnitureTypes.FirstOrDefault(b => b.Id == products.FirstOrDefault(p => p.Id == ps.ProductId).FurnitureTypeId).Name,
                                                      ComePrice = products.FirstOrDefault(p => p.Id == ps.ProductId).ComePrice,
                                                      ComeSumPrice = ps.Amountsold * products.FirstOrDefault(p => p.Id == ps.ProductId).ComePrice,
                                                      GiveOutPrice = productOuts.FirstOrDefault(po => po.Id == ps.ProductOutId).GiveOutPrice,
                                                      GiveOutSumPrice = ps.Amountsold * productOuts.FirstOrDefault(po => po.Id == ps.ProductOutId).GiveOutPrice,
                                                      ComeDataTime = products.FirstOrDefault(p => p.Id == ps.ProductId).ComeDataTime,
                                                      GiveOutDataTime = productOuts.FirstOrDefault(po => po.Id == ps.ProductOutId).GiveOutDataTime,
                                                      BuyerId = productOuts.FirstOrDefault(po => po.Id == ps.ProductOutId).BuyerNameId,
                                                      BuyerName = buyers.FirstOrDefault(b => b.Id == productOuts.FirstOrDefault(po => po.Id == ps.ProductOutId).BuyerNameId).Name
                                                  }).ToList();
            productSoldVMs = productSoldVMs
                .Where(ps => ps.GiveOutDataTime > fitstdateTime)
                .Where(ps => ps.GiveOutDataTime < seconddateTime).ToList();
            return View(productSoldVMs);
        }
    }
}