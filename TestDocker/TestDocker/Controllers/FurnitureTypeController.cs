using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDocker.Data;
using TestDocker.Models;
using TestDocker.ViewsModels;

namespace TestDocker.Controllers
{
    public class FurnitureTypeController : Controller
    {
        private readonly AllContext db;
        public FurnitureTypeController(AllContext context)
        {
            db = context;
        }

        [HttpGet]
        [ActionName("DeleteFurnitureType")]
        public async Task<IActionResult> ConfirmDeleteFurnitureType(int? id)
        {
            if (id != null)
            {
                FurnitureType furnitureType = await db.FurnitureTypes.FirstOrDefaultAsync(f => f.Id == id);
                if (furnitureType != null)
                {
                    FurnitureTypeViewModel model = new FurnitureTypeViewModel()
                    {
                        Id = (int)id,
                        Name = furnitureType.Name,
                        Products = await db.Products.Where(p => p.FurnitureTypeId == id).ToListAsync()
                    };
                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFurnitureType(int? id)
        {
            if (id != null)
            {
                FurnitureType furnitureType = await db.FurnitureTypes.FirstOrDefaultAsync(u => u.Id == id);
                if (furnitureType != null)
                {
                    db.FurnitureTypes.Remove(furnitureType);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Add", "Nomenclature");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFurnitureType(FurnitureType model)
        {
            FurnitureType furnitureType = await db.FurnitureTypes.FirstOrDefaultAsync(u => u.Name == model.Name);

            if (furnitureType == null)
            {
                FurnitureType _furnitureType = new FurnitureType()
                {
                    Name = model.Name
                };
                db.FurnitureTypes.Add(_furnitureType);
                await db.SaveChangesAsync();

            }
            return RedirectToAction("Add", "Nomenclature");
        }


    }
}
