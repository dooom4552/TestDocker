using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class EditNomenclatureViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int BrandCollectionId { get; set; }
        public List<Brand> Brands { get; set; }
        
        public List<BrandCollectionBrandNameViewModel> BrandCollectionBrandNameViewModels { get; set; }
        public List<FurnitureNameViewModel> FurnitureNameViewModels{ get; set; }
        public List<FurnitureType> FurnitureTypes { get; set; }
        public List<FinishingViewModel> FinishingViewModels { get; set; }
        public List<Buyer> Buyers { get; set; }  
        public List<ProductsListVM> ProductsListVMs { get; set; }
        public string BrandCollectionName { get; set; } 
        public string FinishingName { get; set; }
        public string FurName { get; set; }

        #region AddProduct

        #region номенклатура

        /// <summary>ID брэнда</summary>
        public int ProductBrandId { get; set; }

        /// <summary>ID коллекции</summary>
        public int ProductCollectionId { get; set; }

        /// <summary>ID конкретного изделия</summary>
        public int ProductFurnitureNameId { get; set; }

        /// <summary>Id отделки</summary>
        public int ProductFinishingId { get; set; }

        /// <summary>Id типа изделия стол стул кровать и так далее</summary>
        public int ProductFurnitureTypeId { get; set; }
        #endregion

        #region имена пользователей

        /// <summary>Id кладовщика кто принял товар на склад</summary>
        public string ProductStorekeeperComeNameId { get; set; }

        /// <summary>Id мэнеджера кто назначил цену продажи и отправил бухгалтеру</summary>
        public string ProductManagerNameId { get; set; }

        /// <summary>Id бухгалтера кто принял оплату счет или договор или то и то</summary>
        public string ProductAccountantNameId { get; set; }

        /// <summary>Id покупателя кто оплатил</summary>
        public string ProductBuyerName { get; set; }

        /// <summary>Id кладовщика кто выдал товар покупателю</summary>
        public string ProductStorekeeperGiveOutNameId { get; set; }
        #endregion        

        #region накладные договара

        /// <summary>Имя или номер или и то и то документа по которому поступил товар на склад</summary>
        public string ProductComeDocumentName { get; set; }

        /// <summary>Имя договора по которому оплатил покупатель</summary>
        public string ProductContractGiveOutName { get; set; }

        /// <summary>Имя счета по которому оплатил покупатель</summary>
        public string ProductScoreGiveOutName { get; set; }
        #endregion

        #region цены

        /// <summary>Цена товара при поступлении на склад</summary>
        public decimal ProductComePrice { get; set; }

        /// <summary>Цена товара по которой продали товар</summary>
        public decimal ProductGiveOutPrice { get; set; }
        #endregion

        #region даты

        /// <summary>Дата поступления товара на склад</summary>
        public DateTime ProductComeDataTime { get; set; }

        /// <summary>Дата выдачи товара со склада</summary>
        public DateTime ProductGiveOutDataTime { get; set; }
        #endregion

        /// <summary>ID списка одинаковых по номенклатуре товаров</summary>
        public int ProductProductListId { get; set; }

        public int ProductQuantity { get; set; }
        #endregion
    }
}
