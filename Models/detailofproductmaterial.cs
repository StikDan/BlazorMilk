using System;
using System.Collections.Generic;

namespace BlazorMilk.Models
{
    public partial class detailofproductmaterial
    {
        public int idMaterial { get; set; }
        public int idOrderDetails { get; set; }
        public int idProduct { get; set; }

        public virtual material idMaterialNavigation { get; set; } = null!;
        public virtual orderdetail idOrderDetailsNavigation { get; set; } = null!;
        public virtual product idProductNavigation { get; set; } = null!;
    }
}
