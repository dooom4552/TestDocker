using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDocker.Models
{
    /// <summary>
    /// конкретный товар
    /// </summary>
    public class Product
    {        
        public int Id { get; set; }

        #region номенклатура

        /// <summary>Название брэнда</summary>
        public string Brand { get; set; }

        /// <summary>Название коллекции</summary>
        public string Collection { get; set; }

        /// <summary>Название конкретного изделия</summary>
        public string FurnitureName { get; set; }

        /// <summary>Название отделки</summary>
        public string Finishing { get; set; }

        /// <summary>Название типа изделия стол стул кровать и так далее</summary>
        public string FurnitureType { get; set; }
        #endregion

        #region имена пользователей

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
        #endregion        

        #region накладные договара

        /// <summary>Имя или номер или и то и то документа по которому поступил товар на склад</summary>
        public string ComeDocumentName { get; set; }

        /// <summary>Имя договора по которому оплатил покупатель</summary>
        public string ContractGiveOutName { get; set; }

        /// <summary>Имя счета по которому оплатил покупатель</summary>
        public string ScoreGiveOutName { get; set; }
        #endregion

        #region цены

        /// <summary>Цена товара при поступлении на склад</summary>
        public decimal ComePrice { get; set; }

        /// <summary>Цена товара по которой продали товар</summary>
        public decimal GiveOutPrice { get; set; }
        #endregion

        #region даты

        /// <summary>Дата поступления товара на склад</summary>
        public DateTime ComeDataTime { get; set; }

        /// <summary>Дата выдачи товара со склада</summary>
        public DateTime GiveOutDataTime { get; set; }
        #endregion
    }
}
