using System;
using System.Collections.Generic;
using System.Data;
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
            Product product = await db.Products
                .Where(pl => pl.BrandId == model.ProductBrandId)
                .Where(pl => pl.CollectionId == model.ProductCollectionId)
                .Where(pl => pl.FurnitureNameId == model.ProductFurnitureNameId)
                .Where(pl => pl.FinishingId == model.ProductFinishingId)
                .Where(pl => pl.FurnitureTypeId == model.ProductFurnitureTypeId).FirstOrDefaultAsync();

            if (product == null)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);//пользователь который авторизован
                Product _product = new Product()
                {
                    BrandId = model.ProductBrandId,
                    CollectionId = model.ProductCollectionId,
                    FurnitureNameId = model.ProductFurnitureNameId,
                    FinishingId = model.ProductFinishingId,
                    FurnitureTypeId = model.ProductFurnitureTypeId,
                    ComeDataTime = DateTime.Now,
                    StorekeeperComeNameId = user.Id,
                    ComeDocumentName = model.ProductComeDocumentName,
                    ComePrice = model.ProductComePrice,
                    AmountCome = model.ProductQuantity,
                    AmountStock = model.ProductQuantity
                };
                db.Products.Add(_product);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Add", "Nomenclature");
        }

        [HttpPost]
        public async Task<IActionResult> CreateReProduct(EditNomenclatureViewModel model)
        {
            Product product = await db.Products
                .Where(pl => pl.BrandId == model.ProductBrandId)
                .Where(pl => pl.CollectionId == model.ProductCollectionId)
                .Where(pl => pl.FurnitureNameId == model.ProductFurnitureNameId)
                .Where(pl => pl.FinishingId == model.ProductFinishingId)
                .Where(pl => pl.FurnitureTypeId == model.ProductFurnitureTypeId).FirstOrDefaultAsync();

            if (product != null)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);//пользователь который авторизован
                Product _product = new Product()
                {
                    BrandId = model.ProductBrandId,
                    CollectionId = model.ProductCollectionId,
                    FurnitureNameId = model.ProductFurnitureNameId,
                    FinishingId = model.ProductFinishingId,
                    FurnitureTypeId = model.ProductFurnitureTypeId,
                    ComeDataTime = DateTime.Now,
                    StorekeeperComeNameId = user.Id,
                    ComeDocumentName = model.ProductComeDocumentName,
                    ComePrice = model.ProductComePrice,
                    AmountCome = model.ProductQuantity,
                    AmountStock = model.ProductQuantity
                };
                db.Products.Add(_product);
                await db.SaveChangesAsync();
            }

                return RedirectToAction("Add", "Nomenclature");
        }

        public async Task<IActionResult> CreateProductSold(EditNomenclatureViewModel model)
        {
            List<Product> products = await db.Products
                .Where(pl => pl.BrandId == model.ProductBrandId)
                .Where(pl => pl.CollectionId == model.ProductCollectionId)
                .Where(pl => pl.FurnitureNameId == model.ProductFurnitureNameId)
                .Where(pl => pl.FinishingId == model.ProductFinishingId)
                .Where(pl => pl.FurnitureTypeId == model.ProductFurnitureTypeId).ToListAsync();
            if (products.Count > 0)
            {
                if (model.ProductQuantity <= products.Sum(p => p.AmountStock))
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);//пользователь который авторизован
                    ProductOut productOut = new ProductOut()
                    {
                        BrandId = model.ProductBrandId,
                        CollectionId = model.ProductCollectionId,
                        FurnitureNameId = model.ProductFurnitureNameId,
                        FinishingId = model.ProductFinishingId,
                        FurnitureTypeId = model.ProductFurnitureTypeId,
                        ManagerNameId = user.Id,
                        BuyerNameId = model.ProductBuyerId,
                        GiveOutPrice = model.ProductGiveOutPrice,
                        Amountsold = model.ProductQuantity
                    };
                    db.ProductOuts.Add(productOut);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Add", "Nomenclature");
                }
            }



            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteProductSold(int? id)
        {
            if(id != null)
            {
                ProductOut productOut = await db.ProductOuts.FirstOrDefaultAsync(p => p.Id == id);
                if(productOut != null)
                {
                    if(productOut.StorekeeperGiveOutNameId == null)
                    {
                        db.ProductOuts.Remove(productOut);
                       await db.SaveChangesAsync();
                        return RedirectToAction("Add", "Nomenclature");
                    }
                    return Content("Заказ уже исполнен, удалить не возможно");
                }
            }
            return Content("Что-то пошло не так");
        }

        public async Task<IActionResult> СonfirmAccountant(EditNomenclatureViewModel model)
        {
            if (model.ProductOutId != 0)
            {
                if (model.ContractGiveOutName!=null || model.ScoreGiveOutName !=null)
                {
                    ProductOut productOut = await db.ProductOuts.FirstOrDefaultAsync(p => p.Id == model.ProductOutId);
                    if(productOut != null)
                    {
                        User user = await _userManager.FindByNameAsync(User.Identity.Name);//пользователь который авторизован
                        productOut.ContractGiveOutName = model.ContractGiveOutName;
                        productOut.ScoreGiveOutName = model.ScoreGiveOutName;
                        productOut.AccountantNameId = user.Id;
                        await db.SaveChangesAsync();
                        return RedirectToAction("Add", "Nomenclature");
                    }
                }
            }
            return Content("Что-то пошло не так");
        }

        public async Task<IActionResult> СonfirmStorekeeperGiveOut(int? id)
        {
            if (id != null)
            {
                ProductOut productOut = await db.ProductOuts.FirstOrDefaultAsync(p => p.Id == id);
                if (productOut != null)
                {
                    if (productOut.StorekeeperGiveOutNameId == null)
                    {
                        User user = await _userManager.FindByNameAsync(User.Identity.Name);//пользователь который авторизован
                        productOut.StorekeeperGiveOutNameId = user.Id;

                        List<Product> products = await db.Products.Where(p => p.BrandId == productOut.BrandId)
                            .Where(p => p.CollectionId == productOut.CollectionId)
                            .Where(p => p.FurnitureNameId == productOut.FurnitureNameId)
                            .Where(p => p.FinishingId == productOut.FinishingId)
                            .Where(p => p.FurnitureTypeId == productOut.FurnitureTypeId)
                            .Where(p => p.AmountStock>0)
                            .OrderBy(p => p.AmountStock)// есть на складе
                            .ToListAsync();

                        List<ProductSold> ProductSolds = new List<ProductSold>();

                        if(products.Sum(p => p.AmountStock) >= productOut.Amountsold)
                        {
                            int Amountsold = productOut.Amountsold;
                            foreach (Product product in products)
                            {
                                if(product.AmountStock - Amountsold >= 0)
                                {
                                    product.AmountStock = product.AmountStock - Amountsold;
                                    product.Amountsold = product.Amountsold +  Amountsold;

                                    ProductSolds.Add(new ProductSold()
                                    {
                                        ProductId = product.Id,
                                        ProductOutId = productOut.Id,
                                        Amountsold = Amountsold
                                    });
                                    break;
                                }
                                else
                                {                                                                       
                                    Amountsold = Amountsold - product.AmountStock;

                                    ProductSolds.Add(new ProductSold()
                                    {
                                        ProductId = product.Id,
                                        ProductOutId = productOut.Id,
                                        Amountsold = product.AmountStock
                                    });



                                    product.Amountsold = product.AmountCome;
                                    product.AmountStock = 0;
                                }
                                
                            }
                            await db.ProductSolds.AddRangeAsync(ProductSolds);
                            productOut.GiveOutDataTime = DateTime.Now;
                            await db.SaveChangesAsync();
                            return RedirectToAction("Add", "Nomenclature");
                        }


                        
                    }
                }
            }
            return Content("Что-то пошло не так");
        }
    }

   

}


