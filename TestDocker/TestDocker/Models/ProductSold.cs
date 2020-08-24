using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDocker.Models
{
    public class ProductSold
    {
        public int Id { get; set; }

        /// <summary>ID поступления на склад</summary>
        public int ProductId { get; set; }

        /// <summary>ID заказа по которому продали</summary>
        public int ProductOutId { get; set; }

        /// <summary>Сколько продали по заказу</summary>
        public int Amountsold { get; set; }

    }
}
