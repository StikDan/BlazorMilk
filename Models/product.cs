using System;
using System.Collections.Generic;

namespace BlazorMilk.Models
{
    /// <summary>
    /// Продукт
    /// </summary>
    public partial class product
    {
        public product()
        {
            detailofproductmaterials = new HashSet<detailofproductmaterial>();
        }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public int idProduct { get; set; }
        /// <summary>
        /// Название продукта
        /// </summary>
        public string nameProduct { get; set; } = null!;
        /// <summary>
        /// Вес продукта
        /// </summary>
        public double weightProduct { get; set; }
        /// <summary>
        /// Система счисления продукта (кг, г)
        /// </summary>
        public string systemProduct { get; set; } = null!;
        /// <summary>
        /// Количество продукта
        /// </summary>
        public double countProduct { get; set; }
        /// <summary>
        /// Цена продукта
        /// </summary>
        public double priceProduct { get; set; }
        /// <summary>
        /// Код продукта
        /// </summary>
        public string codeProduct { get; set; } = null!;
        /// <summary>
        /// Процент продукта (Сметана 15%)
        /// </summary>
        public double percentProduct { get; set; }

        public virtual ICollection<detailofproductmaterial> detailofproductmaterials { get; set; }
    }
}
