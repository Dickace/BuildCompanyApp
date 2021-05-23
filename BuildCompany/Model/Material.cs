using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class Material
    {
        public Material()
        {
            MaterialLists = new HashSet<MaterialList>();
        }

        public int IdMaterial { get; set; }
        public string MaterialName { get; set; }

        public virtual ICollection<MaterialList> MaterialLists { get; set; }
    }
}
