using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDocker.Data;
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
                Collections = await db.Collections.ToListAsync(),
                FurnitureNames = await db.FurnitureNames.ToListAsync(),
                FurnitureTypes = await db.FurnitureTypes.ToListAsync(),
                Finishings = await db.Finishings.ToListAsync(),
                Buyers = await db.Buyers.ToListAsync()
            };
            return View(model);
        }
    }
}