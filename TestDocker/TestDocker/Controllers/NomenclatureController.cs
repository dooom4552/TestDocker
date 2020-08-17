using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IActionResult> Add()
        {

            EditNomenclatureViewModel model = new EditNomenclatureViewModel()
            {
                Brands = await db.Brands.ToListAsync(),
                FurnitureTypes = await db.FurnitureTypes.ToListAsync(),                
                Buyers = await db.Buyers.ToListAsync()
            };
            List<BrandCollection> BrandCollections = await db.BrandCollections.ToListAsync();
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

            List<FurnitureName> FurnitureNames = await db.FurnitureNames.ToListAsync();
            List<FurnitureNameViewModel> _FurnitureNames = new List<FurnitureNameViewModel>();
            foreach (FurnitureName furnitureName in FurnitureNames)
            {
                _FurnitureNames.Add(new FurnitureNameViewModel() 
                { 
                    Id = furnitureName.Id,
                    Name = furnitureName.Name,
                    BrandName = await GetNameById.GetBrandNameByCollectionId(db, furnitureName.CollectionId),
                    CollectionName = await GetNameById.GetBrandCollectionName(db, furnitureName.CollectionId),
                    CollectionId = furnitureName.CollectionId
                });
            }
            model.FurnitureNameViewModels = _FurnitureNames;

            List<Finishing> finishings = await db.Finishings.ToListAsync();
            List<FinishingViewModel> finishingViewModels = new List<FinishingViewModel>();
            foreach(Finishing finishing in finishings)
            {
                finishingViewModels.Add(new FinishingViewModel() 
                { 
                    Id = finishing.Id,
                    Name = finishing.Name,
                    BrandName = await GetNameById.GetBrandNameByCollectionId(db, finishing.CollectionId),
                    CollectionName = await GetNameById.GetBrandCollectionName(db, finishing.CollectionId),
                    CollectionId = finishing.CollectionId
                });
            }
            model.FinishingViewModels = finishingViewModels;
            return View(model);
        }


        public async Task<IActionResult> Index()
        {
            EditNomenclatureViewModel model = new EditNomenclatureViewModel()
            {
                Brands = await db.Brands.ToListAsync(),
                //FurnitureNames = await db.FurnitureNames.ToListAsync(),
                FurnitureTypes = await db.FurnitureTypes.ToListAsync(),
                //Finishings = await db.Finishings.ToListAsync(),
                Buyers = await db.Buyers.ToListAsync()
            };

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
                    return RedirectToAction("Add");
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
                Brand _brand = new Brand()
                {
                    Name = model.Name
                };
                db.Brands.Add(_brand);
                await db.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return NotFound();
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
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrandCollection(EditNomenclatureViewModel model)
        {
            //string name = await GetNameById.GetBrandNameById(db, model.BrandId);
            //name = name + "\\" + model.BrandCollectionName;
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
                return RedirectToAction("Add");
            }
            return NotFound();
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
                    return RedirectToAction("Add");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFurName(EditNomenclatureViewModel model)
        {
            //string name = await GetNameById.GetBrandCollectionName(db, model.BrandCollectionId);
            //name = name + "\\" + model.FurName;
            FurnitureName furnitureName = await db.FurnitureNames
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
                return RedirectToAction("Add");
            }
            return NotFound();
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
                    string FurnitureName = await GetNameById.GetFurnitureName(db, (int)id);
                    FurnitureNameViewModel model = new FurnitureNameViewModel()
                    {
                        Id = (int)id,
                        Name = furnitureName.Name,
                        Products = await db.Products.Where(p => p.FurnitureName == FurnitureName).ToListAsync(),
                    };
                    return View(model);
                }               
            }
            return NotFound();
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
                    return RedirectToAction("Add");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinishing(EditNomenclatureViewModel model)
        {
            //string name = await GetNameById.GetBrandCollectionName(db, model.BrandCollectionId);
            //name = name + "\\" + model.FinishingName;
            Finishing finishing = await db.Finishings
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
                return RedirectToAction("Add");
            }
            return NotFound();
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
                    string finishingName = await GetNameById.GetFinishingName(db, (int)id);
                    FinishingViewModel model = new FinishingViewModel()
                    {
                        Id = (int)id,
                        Name = finishing.Name,
                        Products = await db.Products.Where(p => p.Finishing== finishingName).ToListAsync(),
                    };
                    return View(model);
                }
            }
            return NotFound();
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
                    return RedirectToAction("Add");
                }
            }
            return NotFound();
        }
    }
}