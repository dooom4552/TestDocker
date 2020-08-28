using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using TestDocker.Data;
using TestDocker.Models;
using TestDocker.Services;
using TestDocker.ViewsModels;

namespace TestDocker.Controllers
{
    [Authorize(Roles = "manager, director, storekeeper, accountant")]
    public class NomenclatureController : Controller
    {
        readonly UserManager<User> _userManager;

        private readonly AllContext db;
        public NomenclatureController(AllContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Add()
        {

            EditNomenclatureViewModel model = new EditNomenclatureViewModel()
            {
                Brands = await db.Brands.ToListAsync(),
                FurnitureTypes = await db.FurnitureTypes.ToListAsync(),
                Buyers = await db.Buyers.ToListAsync(),
            };
            List<BrandCollection> BrandCollections = await db.BrandCollections.ToListAsync();
            List<Finishing> finishings = await db.Finishings.ToListAsync();
            List<FurnitureName> FurnitureNames = await db.FurnitureNames.ToListAsync();

            List<BrandCollectionBrandNameViewModel> _BrandCollectionsVM = new List<BrandCollectionBrandNameViewModel>();
            foreach (BrandCollection brandCollection in BrandCollections)
            {
                _BrandCollectionsVM.Add(new BrandCollectionBrandNameViewModel()
                {
                    BrandId = brandCollection.BrandId,
                    BrandName = await GetNameById.GetBrandNameByCollectionId(db, brandCollection.Id),
                    Id = brandCollection.Id,
                    Name = brandCollection.Name
                });
            }
            model.BrandCollectionBrandNameViewModels = _BrandCollectionsVM;


            List<FurnitureNameViewModel> _FurnitureNames = new List<FurnitureNameViewModel>();
            foreach (FurnitureName furnitureName in FurnitureNames)
            {
                _FurnitureNames.Add(new FurnitureNameViewModel()
                {
                    Id = furnitureName.Id,
                    Name = furnitureName.Name,
                    BrandName = await GetNameById.GetBrandNameByCollectionId(db, furnitureName.CollectionId),
                    CollectionName = await GetINameById<BrandCollection>.GetNameAsync(await db.BrandCollections.ToListAsync(), furnitureName.CollectionId),
                    CollectionId = furnitureName.CollectionId
                });
            }
            model.FurnitureNameViewModels = _FurnitureNames;


            List<FinishingViewModel> finishingViewModels = new List<FinishingViewModel>();
            foreach (Finishing finishing in finishings)
            {
                finishingViewModels.Add(new FinishingViewModel()
                {
                    Id = finishing.Id,
                    Name = finishing.Name,
                    BrandName = await GetNameById.GetBrandNameByCollectionId(db, finishing.CollectionId),
                    CollectionName = await GetINameById<BrandCollection>.GetNameAsync(await db.BrandCollections.ToListAsync(), finishing.CollectionId),
                    CollectionId = finishing.CollectionId
                });
            }
            model.FinishingViewModels = finishingViewModels;

            List<Product> products = await db.Products.ToListAsync();

            List<ProductVM> grouped = (from p in products
                          group p by new
                          {
                              BrandId=p.BrandId,
                              BrandCollectionId = p.CollectionId,
                              FurnitureNameId = p.FurnitureNameId,
                              FinishingId = p.FinishingId,
                              FurnitureTypeId = p.FurnitureTypeId,
                              Brand = GetINameById<Brand>.GetName(model.Brands, p.BrandId),
                              BrandCollection = GetINameById<BrandCollection>.GetName(BrandCollections, p.CollectionId),
                              FurnitureName = GetINameById<FurnitureName>.GetName(FurnitureNames, p.FurnitureNameId),
                              Finishing = GetINameById<Finishing>.GetName(finishings, p.FinishingId),
                              FurnitureType = GetINameById<FurnitureType>.GetName(model.FurnitureTypes, p.FurnitureTypeId)
                          }
                          into grp
                          select new ProductVM
                          {
                              BrandId = grp.Key.BrandId,
                              BrandCollectionId = grp.Key.BrandCollectionId,
                              FurnitureNameId = grp.Key.FurnitureNameId,
                              FinishingId = grp.Key.FinishingId,
                              FurnitureTypeId = grp.Key.FurnitureTypeId,
                              Brand = grp.Key.Brand,
                              BrandCollection = grp.Key.BrandCollection,
                              FurnitureName =  grp.Key.FurnitureName,
                              Finishing = grp.Key.Finishing,
                              FurnitureType = grp.Key.FurnitureType,
                              SumPrice = grp.Sum(p => p.ComePrice*p.AmountStock),
                           
                              AmountStock = grp.Sum(p => p.AmountStock),
                              LastPrice = grp.OrderByDescending(p => p .ComeDataTime).FirstOrDefault().ComePrice
                          }).ToList();
            //comeprices.Sum().ToString("C2", CultureInfo.CreateSpecificCulture("eu-ES")),
            model.ProductVMs = grouped;

            List<ProductOut> productOuts = await db.ProductOuts.ToListAsync();
            List<ProductOutVM> productOutVMs = (from p in productOuts
                                               select new ProductOutVM
                                               {
                                                   BrandId = p.BrandId,
                                                   CollectionId =p.CollectionId,
                                                   FurnitureNameId = p.FurnitureNameId,
                                                   FinishingId = p.FinishingId,
                                                   FurnitureTypeId = p.FurnitureTypeId,
                                                   Id = p.Id,
                                                   AccountantNameId = p.AccountantNameId,
                                                   BuyerNameId = p.BuyerNameId,
                                                   ManagerNameId = p.ManagerNameId,
                                                   Amountsold= p.Amountsold,
                                                   ContractGiveOutName = p.ContractGiveOutName,
                                                   ScoreGiveOutName = p.ScoreGiveOutName,
                                                   GiveOutDataTime = p.GiveOutDataTime,
                                                   GiveOutPrice = p.GiveOutPrice,
                                                   StorekeeperGiveOutNameId= p.StorekeeperGiveOutNameId,
                                                   Brand = GetINameById<Brand>.GetName(model.Brands, p.BrandId),
                                                   BrandCollection = GetINameById<BrandCollection>.GetName(BrandCollections, p.CollectionId),
                                                   FurnitureName = GetINameById<FurnitureName>.GetName(FurnitureNames, p.FurnitureNameId),
                                                   Finishing = GetINameById<Finishing>.GetName(finishings, p.FinishingId),
                                                   FurnitureType = GetINameById<FurnitureType>.GetName(model.FurnitureTypes, p.FurnitureTypeId),
                                                   BuyerName = GetINameById<Buyer>.GetName(model.Buyers, p.BuyerNameId),
                                                   SumPrice = p.GiveOutPrice*p.Amountsold
                                               }).ToList();
            model.ProductOutVMs = productOutVMs;
            return View(model);
        }

        [HttpGet]
        [ActionName("DeleteBrand")]
        public async Task<IActionResult> ConfirmDeleteBrand(int? id)
        {
            if (id != null)
            {
                Brand brand = await db.Brands.FirstOrDefaultAsync(u => u.Id == id);
                if (brand != null)
                {
                    BrandViewModel model = new BrandViewModel()
                    {
                        Id = (int)id,
                        Name = brand.Name,
                        BrandCollections = await db.BrandCollections.Where(ye => ye.BrandId == id).ToListAsync()
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrand(int? id)
        {
            if (id != null)
            {
                Brand brand = await db.Brands.FirstOrDefaultAsync(u => u.Id == id);
                if (brand != null)
                {
                    db.Brands.Remove(brand);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Add");
                }
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(Brand model)
        {
            Brand brand = await db.Brands.FirstOrDefaultAsync(u => u.Name == model.Name);

            if (brand == null)
            {
                Brand _brand = new Brand()
                {
                    Name = model.Name
                };
                db.Brands.Add(_brand);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> BrandDetails(int? id)
        {
            Brand brand = await db.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (brand != null)
            {
                BrandViewModel brandViewModel = new BrandViewModel()
                {
                    Id = (int)id,
                    Name = brand.Name,
                    BrandCollections = await db.BrandCollections.Where(bc => bc.BrandId == id).ToListAsync()
                };
                return View(brandViewModel);
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrandCollection(EditNomenclatureViewModel model)
        {
            BrandCollection brandCollection = await db.BrandCollections.FirstOrDefaultAsync(u => u.Name == model.BrandCollectionName);

            if (brandCollection == null)
            {
                BrandCollection _brandCollection = new BrandCollection()
                {
                    Name = model.BrandCollectionName,
                    BrandId = model.BrandId
                };
                db.BrandCollections.Add(_brandCollection);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        [ActionName("DeleteBrandCollection")]
        public async Task<IActionResult> ConfirmDeleteBrandCollection(int? id)
        {
            if (id != null)
            {
                BrandCollection brandCollection = await db.BrandCollections.FirstOrDefaultAsync(b => b.Id == id);
                if (brandCollection != null)
                {
                    BrandCollectionViewModel model = new BrandCollectionViewModel()
                    {
                        Id = (int)id,
                        Name = brandCollection.Name,
                        Finishings = await db.Finishings.Where(f => f.CollectionId == (int)id).ToListAsync(),
                        FurnitureNames = await db.FurnitureNames.Where(f => f.CollectionId == (int)id).ToListAsync()
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrandCollection(int? id)
        {
            if (id != null)
            {
                BrandCollection brandCollection = await db.BrandCollections
                    .FirstOrDefaultAsync(b => b.Id == (int)id);
                if (brandCollection != null)
                {
                    db.BrandCollections.Remove(brandCollection);
                    await db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFurName(EditNomenclatureViewModel model)
        {
            FurnitureName furnitureName = await db.FurnitureNames
                .Where(f => f.CollectionId == model.BrandCollectionId)
                .FirstOrDefaultAsync(f => f.Name == model.FurName);
            if (furnitureName == null)
            {
                FurnitureName _furnitureName = new FurnitureName
                {
                    CollectionId = model.BrandCollectionId,
                    Name = model.FurName
                };
                db.FurnitureNames.Add(_furnitureName);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        [ActionName("DeleteFurnitureName")]
        public async Task<IActionResult> ConfirmDeleteFurnitureName(int? id)
        {
            if (id != null)
            {
                FurnitureName furnitureName = await db.FurnitureNames.FirstOrDefaultAsync(b => b.Id == id);
                if (furnitureName != null)
                {
                    FurnitureNameViewModel model = new FurnitureNameViewModel()
                    {
                        Id = (int)id,
                        Name = furnitureName.Name,
                        Products = await db.Products.Where(p => p.FurnitureNameId == (int)id).ToListAsync(),
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFurnitureName(int? id)
        {
            if (id != null)
            {
                FurnitureName furnitureName = await db.FurnitureNames
                    .FirstOrDefaultAsync(b => b.Id == id);
                if (furnitureName != null)
                {
                    db.FurnitureNames.Remove(furnitureName);
                    await db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinishing(EditNomenclatureViewModel model)
        {
            Finishing finishing = await db.Finishings
                .Where(f => f.CollectionId == model.BrandCollectionId)
                .FirstOrDefaultAsync(f => f.Name == model.FinishingName);
            if (finishing == null)
            {
                Finishing _finishing = new Finishing
                {
                    CollectionId = model.BrandCollectionId,
                    Name = model.FinishingName
                };
                db.Finishings.Add(_finishing);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        [ActionName("DeleteFinishing")]
        public async Task<IActionResult> ConfirmDeleteFinishing(int? id)
        {
            if (id != null)
            {
                Finishing finishing = await db.Finishings.FirstOrDefaultAsync(b => b.Id == id);
                if (finishing != null)
                {
                    string finishingName = await GetINameById<Finishing>.GetNameAsync( await db.Finishings.ToListAsync(), (int)id);
                    FinishingViewModel model = new FinishingViewModel()
                    {
                        Id = (int)id,
                        Name = finishing.Name,
                        Products = await db.Products.Where(p => p.FinishingId == id).ToListAsync(),
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFinishing(int? id)
        {
            if (id != null)
            {
                Finishing finishing = await db.Finishings
                    .FirstOrDefaultAsync(b => b.Id == id);
                if (finishing != null)
                {
                    db.Finishings.Remove(finishing);
                    await db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Add");
        }
    }
}