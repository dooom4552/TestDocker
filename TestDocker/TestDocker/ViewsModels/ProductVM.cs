using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class ProductVM
    {
        #region номентклатура
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

        #region ID
        public int BrandId { get; set; }
        public int BrandCollectionId { get; set; }
        public int FurnitureNameId { get; set; }
        public int FinishingId { get; set; }
        public int FurnitureTypeId { get; set; }
        #endregion


        /// <summary>Количество на складе</summary>
        public int AmountStock { get; set; }

        /// <summary>Сумма цен всех товаров данной номенкатуры</summary>
        public float SumPrice { get; set; }

        /// <summary>Последняя цена продажи</summary>
        public float LastPrice { get; set; }
    }
}
