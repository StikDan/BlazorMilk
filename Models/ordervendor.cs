using System;
using System.Collections.Generic;

namespace BlazorMilk.Models
{
    /// <summary>
    /// Заказ от вендора
    /// </summary>
    public partial class ordervendor
    {
        public ordervendor()
        {
            orderdetails = new HashSet<orderdetail>();
        }

        public int idOrder { get; set; }
        /// <summary>
        /// Исполнитель
        /// </summary>
        public string executor { get; set; } = null!;
        /// <summary>
        /// Заказчик
        /// </summary>
        public string customer { get; set; } = null!;
        /// <summary>
        /// Итого
        /// </summary>
        public double? total { get; set; }
        /// <summary>
        /// Айди вендора
        /// </summary>
        public string idVendor { get; set; } = null!;

        public virtual vendor idVendorNavigation { get; set; } = null!;
        public virtual ICollection<orderdetail> orderdetails { get; set; }
    }
}
