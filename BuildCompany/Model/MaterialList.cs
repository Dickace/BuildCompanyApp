using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class MaterialList
    {
        public int IdMaterialList { get; set; }
        public int? IdMaterial { get; set; }
        public int? IdOrder { get; set; }
        public int? MaterialCounts { get; set; }
        public DateTime? MaterialEndDate { get; set; }

        public virtual Material IdMaterialNavigation { get; set; }
        public virtual Order IdOrderNavigation { get; set; }
    }
}
