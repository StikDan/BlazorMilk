using System;
using System.Collections.Generic;

namespace BlazorMilk.Models
{
    public partial class orderdetail
    {
        public orderdetail()
        {
            detailofproductmaterials = new HashSet<detailofproductmaterial>();
        }

        public int idOrderDetails { get; set; }
        public string nameProduct { get; set; } = null!;
        public int countProduct { get; set; }
        public string systemProduct { get; set; } = null!;
        public double priceDetail { get; set; }
        public DateOnly dateOrder { get; set; }
        public int idOrder { get; set; }

        public virtual ordervendor idOrderNavigation { get; set; } = null!;
        public virtual ICollection<detailofproductmaterial> detailofproductmaterials { get; set; }
    }
}
