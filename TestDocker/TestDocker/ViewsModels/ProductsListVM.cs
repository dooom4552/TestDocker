using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class ProductsListVM
    {
        #region старое
        /// <summary>Количество на складе</summary>
        public int AmountStock { get; set; }

        /// <summary>Количество продано</summary>
        public int Amountsold { get; set; }

        #region цены

        /// <summary>Цена товара при поступлении на склад</summary>
        public string ComeSumPrice { get; set; }

        /// <summary>Цена товара по которой продали товар</summary>
        public string GiveOutSumPrice { get; set; }
        #endregion
        public List<ProductVM> ProductVMs { get; set; }
        #endregion

       public List<Product> Products { get; set; }
    }
}
