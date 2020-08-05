using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDocker.Data;
using TestDocker.Models;
using TestDocker.Services;
using TestDocker.ViewsModels;

namespace TestDocker.Controllers
{
    [Authorize(Roles = "manager")]
    public class NomenclatureController : Controller
    {
        private readonly AllContext db;
        public NomenclatureController(AllContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            EditNomenclatureViewModel model = new EditNomenclatureViewModel()
            {
                Brands = await db.Brands.ToListAsync(),
                BrandCollections = await db.BrandCollections.ToListAsync(),
                FurnitureNames = await db.FurnitureNames.ToListAsync(),
                FurnitureTypes = await db.FurnitureTypes.ToListAsync(),
                Finishings = await db.Finishings.ToListAsync(),
                Buyers = await db.Buyers.ToListAsync()
            };
            return View(model);
        }
        #region Brand
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
            return NotFound();
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
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(Brand model)
        {
            Brand brand = await db.Brands.FirstOrDefaultAsync(u => u.Name == model.Name);

            if (brand == null)
            {
                Brand _brand= new Brand()
                {
                    Name = model.Name
                };
                db.Brands.Add(_brand);
                await db.SaveChangesAsync();
                
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> BrandDetails(int? id)
        {
            Brand brand = await db.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if(brand != null)
            {
                BrandViewModel brandViewModel = new BrandViewModel()
                {
                    Id = (int)id,
                    Name = brand.Name,
                    BrandCollections = await db.BrandCollections.Where(bc => bc.BrandId == id).ToListAsync()
                };
                return View(brandViewModel);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region BrandCollection
        [HttpPost]
        public async Task<IActionResult> CreateBrandCollection(BrandViewModel model)
        {
            BrandCollection brandCollection  = await db.BrandCollections
                .Where(u => u.BrandId == model.Id)
                .FirstOrDefaultAsync(u => u.Name == model.BrandCollectionName);

            if (brandCollection == null)
            {
                BrandCollection _brandCollection = new BrandCollection()
                {
                    Name = model.BrandCollectionName,
                    BrandId=model.Id
                };
                db.BrandCollections.Add(_brandCollection);
                await db.SaveChangesAsync();               
            }
            return RedirectToAction("BrandDetails", new { id = model.Id });
        }

        [HttpGet]
        [ActionName("DeleteBrandCollection")]
        public async Task<IActionResult> ConfirmDeleteBrandCollection(int? id)
        {
            if (id != null)
            {
                BrandCollection brandCollection = await db.BrandCollections.FirstOrDefaultAsync(u => u.Id == id);
                if (brandCollection != null)
                {
                    BrandCollectionViewModel model = new BrandCollectionViewModel()
                    {
                        Id = (int)id,
                        Name = brandCollection.Name,
                        FurnitureNames = await db.FurnitureNames.Where(ye => ye.CollectionId == id).ToListAsync(),
                        Finishings = await db.Finishings.Where(f => f.CollectionId == id).ToListAsync()
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrandCollection(int? id)
        {
            if (id != null)
            {
                BrandCollection brandCollection = await db.BrandCollections.FirstOrDefaultAsync(u => u.Id == id);
                if (brandCollection != null)
                {
                    db.BrandCollections.Remove(brandCollection);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("BrandDetails", new { id = brandCollection.BrandId });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> BrandCollectionDetails(int? id)
        {
            BrandCollection brandCollection = await db.BrandCollections.FirstOrDefaultAsync(b => b.Id == id);
            if (brandCollection != null)
            {
                BrandCollectionViewModel brandCollectionViewModel = new BrandCollectionViewModel()
                {
                    Id = (int)id,
                    Name = brandCollection.Name,
                    FurnitureNames = await db.FurnitureNames.Where(bc => bc.CollectionId == id).ToListAsync(),
                    Finishings = await db.Finishings.Where(f => f.CollectionId == id).ToListAsync()
                };
                return View(brandCollectionViewModel);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region FurnitureName
        [HttpPost]
        public async Task<IActionResult> CreateFurnirureName(BrandCollectionViewModel model)
        {
            FurnitureName furnitureName = await db.FurnitureNames
                .Where(u => u.CollectionId == model.Id)
                .FirstOrDefaultAsync(u => u.Name == model.FurnitureName);

            if (furnitureName == null)
            {
                FurnitureName _furnitureName = new FurnitureName()
                {
                    Name = model.FurnitureName,
                    CollectionId = model.Id,                    
                };
                db.FurnitureNames.Add(_furnitureName);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("BrandCollectionDetails", new { id = model.Id });
        }

        [HttpGet]
        [ActionName("DeleteFurnitureName")]
        public async Task<IActionResult> ConfirmDeleteFurnitureName(int? id)
        {
            if (id != null)
            {
                FurnitureName furnitureName = await db.FurnitureNames.FirstOrDefaultAsync(u => u.Id == id);
                if (furnitureName != null)
                {
                    string _brandName = await GetNameById.GetBrandNameByCollectionId(db, furnitureName.CollectionId);
                    string _brandCollectionName = await GetNameById.GetBrandCollectionName(db, furnitureName.CollectionId);
                    string _furnitureName = await GetNameById.GetFurnitureName(db, (int)id);
                    
                    FurnitureNameViewModel model = new FurnitureNameViewModel()
                    {
                        Id = (int)id,
                        Name = furnitureName.Name,
                        Products = await db.Products
                        .Where(p => p.Brand == _brandName)
                        .Where(p => p.Collection == _brandCollectionName)
                        .Where( p => p.FurnitureName == _furnitureName)                       
                        .ToListAsync()
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFurnitureName(int? id)
        {
            if (id != null)
            {
                FurnitureName furnitureName = await db.FurnitureNames.FirstOrDefaultAsync(u => u.Id == id);
                if (furnitureName != null)
                {
                    db.FurnitureNames.Remove(furnitureName);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("BrandCollectionDetails", new { id = furnitureName.CollectionId });
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region finishing
        [HttpPost]
        public async Task<IActionResult> CreateFinishing(BrandCollectionViewModel model)
        {
            Finishing finishing = await db.Finishings
                .Where(u => u.CollectionId == model.Id)
                .FirstOrDefaultAsync(u => u.Name == model.FinishingName);

            if (finishing == null)
            {
                Finishing _finishing = new Finishing()
                {
                    Name = model.FinishingName,
                    CollectionId = model.Id,
                };
                db.Finishings.Add(_finishing);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("BrandCollectionDetails", new { id = model.Id });
        }

        [HttpGet]
        [ActionName("DeleteFinishing")]
        public async Task<IActionResult> ConfirmDeleteFinishing(int? id)
        {
            if (id != null)
            {
                Finishing finishing = await db.Finishings.FirstOrDefaultAsync(u => u.Id == id);
                if (finishing != null)
                {
                    string _brandName = await GetNameById.GetBrandNameByCollectionId(db, finishing.CollectionId);
                    string _brandCollectionName = await GetNameById.GetBrandCollectionName(db, finishing.CollectionId);
                    string _finishingName = await GetNameById.GetFinishingName(db, (int)id);

                    FinishingViewModel model = new FinishingViewModel()
                    {
                        Id = (int)id,
                        Name = finishing.Name,
                        Products = await db.Products
                        .Where(p => p.Brand == _brandName)
                        .Where(p => p.Collection == _brandCollectionName)
                        .Where(p => p.FurnitureName == _finishingName)
                        .ToListAsync()
                    };
                    return View(model);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFinishing(int? id)
        {
            if (id != null)
            {
                Finishing finishing = await db.Finishings.FirstOrDefaultAsync(u => u.Id == id);
                if (finishing != null)
                {
                    db.Finishings.Remove(finishing);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("BrandCollectionDetails", new { id = finishing.CollectionId });
            }
            return RedirectToAction("Index");
        }
        #endregion
    }

}