using System;
using System.Collections.Generic;

namespace BlazorMilk.Models
{
    /// <summary>
    /// Вендор (заинтересованные лица)
    /// </summary>
    public partial class vendor
    {
        public vendor()
        {
            ordervendors = new HashSet<ordervendor>();
        }

        /// <summary>
        /// Идентификатор в строковом виде
        /// </summary>
        public string id { get; set; } = null!;
        /// <summary>
        /// Имя вендора
        /// </summary>
        public string nameVendor { get; set; } = null!;
        /// <summary>
        /// ИНН вендора
        /// </summary>
        public string? innVendor { get; set; }
        /// <summary>
        /// Адрес вендора 
        /// </summary>
        public string addressVendor { get; set; } = null!;
        /// <summary>
        /// Телефон вендора
        /// </summary>
        public string phoneVendor { get; set; } = null!;
        /// <summary>
        /// Продавец
        /// </summary>
        public sbyte salesman { get; set; }
        /// <summary>
        /// Покупатель
        /// </summary>
        public sbyte buyer { get; set; }

        public virtual ICollection<ordervendor> ordervendors { get; set; }
    }
}
