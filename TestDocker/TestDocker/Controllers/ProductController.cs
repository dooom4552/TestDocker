using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDocker.Data;
using TestDocker.Models;
using TestDocker.ViewsModels;

namespace TestDocker.Controllers
{
    public class ProductController : Controller
    {
        readonly UserManager<User> _userManager;

        private readonly AllContext db;
        public ProductController(AllContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(EditNomenclatureViewModel model)
        {
            ///проверка на попытку создания экземпляра ProductList который уже существует
            ProductList productList = await db.ProductLists
                .Where(pl => pl.BrandId == model.ProductBrandId)
                .Where(pl => pl.CollectionId == model.ProductCollectionId)
                .Where(pl => pl.FurnitureNameId == model.ProductFurnitureNameId)
                .Where(pl => pl.FinishingId == model.ProductFinishingId)
                .Where(pl => pl.FurnitureTypeId == model.ProductFurnitureTypeId).FirstOrDefaultAsync();

            if(productList == null)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);//пользователь который авторизован 

                ProductList _productList = new ProductList()
                {
                    BrandId= model.ProductBrandId,
                    CollectionId = model.ProductCollectionId,
                    FurnitureNameId = model.ProductFurnitureNameId,
                    FinishingId = model.ProductFinishingId,
                    FurnitureTypeId = model.ProductFurnitureTypeId
                };

                db.ProductLists.Add(_productList);
                await db.SaveChangesAsync();
                for (int i =0; i< model.ProductQuantity; i++)
                {
                    Product product = new Product()
                    {
                        BrandId= model.ProductBrandId,
                        CollectionId = model.ProductCollectionId,
                        FurnitureNameId = model.ProductFurnitureNameId,
                        FinishingId = model.ProductFinishingId,
                        FurnitureTypeId = model.ProductFinishingId,
                        StorekeeperComeNameId = user.Id,
                        ComeDocumentName = model.ProductComeDocumentName,
                        ComePrice = model.ProductComePrice,
                        ComeDataTime = DateTime.Now,
                        ProductListId = _productList.Id
                    };
                    db.Products.Add(product);
                    await db.SaveChangesAsync();
                }

            }
            return RedirectToAction("Add", "Nomenclature");
        }
    }
}
