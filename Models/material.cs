using System;
using System.Collections.Generic;

namespace BlazorMilk.Models
{
    /// <summary>
    /// Материал
    /// </summary>
    public partial class material
    {
        public material()
        {
            detailofproductmaterials = new HashSet<detailofproductmaterial>();
        }

        /// <summary>
        /// Идентификатор материала
        /// </summary>
        public int idMaterial { get; set; }
        /// <summary>
        /// Название материала
        /// </summary>
        public string nameMaterial { get; set; } = null!;
        /// <summary>
        /// Система счисления материала (кг, г)
        /// </summary>
        public string systemMaterial { get; set; } = null!;
        /// <summary>
        /// Количество материала
        /// </summary>
        public double countMaterial { get; set; }
        /// <summary>
        /// Цена материала
        /// </summary>
        public double priceMaterial { get; set; }
        /// <summary>
        /// Код материала
        /// </summary>
        public string codeMaterial { get; set; } = null!;

        public virtual ICollection<detailofproductmaterial> detailofproductmaterials { get; set; }
    }
}
