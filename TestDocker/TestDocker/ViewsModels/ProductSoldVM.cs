using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class ProductSoldVM: ProductSold
    {
        #region номенклатура ID

        /// <summary>ID брэнда</summary>
        public int BrandId { get; set; }

        /// <summary>ID коллекции</summary>
        public int CollectionId { get; set; }

        /// <summary>ID конкретного изделия</summary>
        public int FurnitureNameId { get; set; }

        /// <summary>Id отделки</summary>
        public int FinishingId { get; set; }

        /// <summary>Id типа изделия стол стул кровать и так далее</summary>
        public int FurnitureTypeId { get; set; }
        #endregion

        #region номенклатура Name
        /// <summary>Имя брэнда</summary>
        public string Brand { get; set; }
        /// <summary>Имя коллекции</summary>
        public string BrandCollection { get; set; }
        /// <summary>Имя конкретного изделия</summary>
        public string FurnitureName { get; set; }

        /// <summary>Имя отделки</summary>
        public string Finishing { get; set; }

        /// <summary>Имя типа изделия</summary>
        public string FurnitureType { get; set; }
        #endregion

        #region цены

        /// <summary>Цена товара при поступлении на склад</summary>
        public float ComePrice { get; set; }

        /// <summary>Цена цена продажи товара</summary>
        public float GiveOutPrice { get; set; }

        /// <summary>Сумма цен всех товаров по прожаже</summary>
        public float GiveOutSumPrice { get; set; }

        /// <summary>Сумма цен всех товаров при поступлении</summary>
        public float ComeSumPrice { get; set; }

        /// <summary>Цена товара по которой продали товар</summary>
        //public decimal GiveOutPrice { get; set; }
        #endregion

        #region даты
        /// <summary>Дата поступления товара на склад</summary>
        public DateTime ComeDataTime { get; set; }

        /// <summary>Дата выдачи товара со склада</summary>
        public DateTime GiveOutDataTime { get; set; }
        #endregion

        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
    }
}
