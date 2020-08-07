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

        public async Task<IActionResult> Add()
        {

            EditNomenclatureViewModel model = new EditNomenclatureViewModel()
            {
                Brands = await db.Brands.ToListAsync(),                
                FurnitureNames = await db.FurnitureNames.ToListAsync(),
                FurnitureTypes = await db.FurnitureTypes.ToListAsync(),
                Finishings = await db.Finishings.ToListAsync(),
                Buyers = await db.Buyers.ToListAsync()
            };
            List<BrandCollection> BrandCollections = await db.BrandCollections.ToListAsync();
            List<BrandCollectionBrandNameViewModel> _BrandCollectionsVM = new List<BrandCollectionBrandNameViewModel>();
            foreach (BrandCollection  brandCollection in BrandCollections)
            {
                _BrandCollectionsVM.Add(new BrandCollectionBrandNameViewModel() 
                { 
                BrandId= brandCollection.BrandId,
                BrandName=await GetNameById.GetBrandNameByCollectionId(db, brandCollection.Id),
                Id=brandCollection.Id,
                Name=brandCollection.Name
                });
            }
            model.BrandCollectionBrandNameViewModels = _BrandCollectionsVM;
            return View(model);
        }


        public async Task<IActionResult> Index()
        {
            EditNomenclatureViewModel model = new EditNomenclatureViewModel()
            {
                Brands = await db.Brands.ToListAsync(),                
                FurnitureNames = await db.FurnitureNames.ToListAsync(),
                FurnitureTypes = await db.FurnitureTypes.ToListAsync(),
                Finishings = await db.Finishings.ToListAsync(),
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
                return RedirectToAction("Index");
            }
            return NotFound();
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
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrandCollection(BrandViewModel model)
        {
            BrandCollection brandCollection  = await db.BrandCollections.FirstOrDefaultAsync(u => u.Name == model.BrandCollectionName);

            if (brandCollection == null)
            {
                BrandCollection _brandCollection = new BrandCollection()
                {
                    Name = model.BrandCollectionName,
                    BrandId=model.Id
                };
                db.BrandCollections.Add(_brandCollection);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }

}