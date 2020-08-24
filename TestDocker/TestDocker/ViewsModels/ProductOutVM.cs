using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class ProductOutVM:ProductOut
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

        public string BuyerName { get; set; }

        /// <summary>Сумма цен всех товаров данной номенкатуры</summary>
        public float SumPrice { get; set; }

    }
}
