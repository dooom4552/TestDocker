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

        #region имена пользователей

        /// <summary>Id кладовщика кто принял товар на склад</summary>
        public string StorekeeperComeNameId { get; set; }

        /// <summary>Id мэнеджера кто назначил цену продажи и отправил бухгалтеру</summary>
        public string ManagerNameId { get; set; }

        /// <summary>Id бухгалтера кто принял оплату счет или договор или то и то</summary>
        public string AccountantNameId { get; set; }

        /// <summary>Id покупателя кто оплатил</summary>
        public string BuyerNameId { get; set; }

        /// <summary>Id кладовщика кто выдал товар покупателю</summary>
        public string StorekeeperGiveOutNameId { get; set; }
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
