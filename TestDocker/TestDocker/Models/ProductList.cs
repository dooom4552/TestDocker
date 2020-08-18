using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDocker.Models
{
    public class ProductList
    {
        public int Id { get; set; }

        #region номенклатура

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
    }
}
