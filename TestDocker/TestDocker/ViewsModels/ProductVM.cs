using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.Models;

namespace TestDocker.ViewsModels
{
    public class ProductVM : Product
    {
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

        /// <summary>Имя кладовщика кто принял товар на склад</summary>
        public string StorekeeperComeName { get; set; }

        /// <summary>Имя мэнеджера кто назначил цену продажи и отправил бухгалтеру</summary>
        public string ManagerName { get; set; }

        /// <summary>Имя бухгалтера кто принял оплату счет или договор или то и то</summary>
        public string AccountantName { get; set; }

        /// <summary>Имя покупателя кто оплатил</summary>
        public string BuyerName { get; set; }

        /// <summary>Имя кладовщика кто выдал товар покупателю</summary>
        public string StorekeeperGiveOutName { get; set; }

    }
}
