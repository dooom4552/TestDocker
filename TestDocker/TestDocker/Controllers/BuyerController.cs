﻿using System;
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
    public class BuyerController : Controller
    {
        private readonly AllContext db;

        public BuyerController(AllContext context)
        {
            db = context;
        }

        [HttpGet]
        [ActionName("DeleteBuyer")]
        public async Task<IActionResult> ConfirmDeleteBuyer(int? id)
        {
            if (id != null)
            {
                Buyer buyer = await db.Buyers.FirstOrDefaultAsync(f => f.Id == id);
                if (buyer != null)
                {
                    BuyerViewModel model = new BuyerViewModel()
                    {
                        Id = (int)id,
                        Name = buyer.Name,
                        Products = await db.Products.Where(p => p.FurnitureType == buyer.Name).ToListAsync()
                    };
                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBuyer(int? id)
        {
            if (id != null)
            {
                Buyer buyer = await db.Buyers.FirstOrDefaultAsync(u => u.Id == id);
                if (buyer != null)
                {
                    db.Buyers.Remove(buyer);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Nomenclature");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBuyer(Buyer model)
        {
            Buyer buyer = await db.Buyers.FirstOrDefaultAsync(u => u.Name == model.Name);

            if (buyer == null)
            {
                Buyer _buyer = new Buyer()
                {
                    Name = model.Name
                };
                db.Buyers.Add(_buyer);
                await db.SaveChangesAsync();

            }
            return RedirectToAction("Index", "Nomenclature");
        }

    }
}