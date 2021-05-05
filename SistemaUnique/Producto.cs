using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaUnique
{
    public class Producto
    {
        public int cod_prod { get; set; }
        public string nom_prod { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }
        public int cat_prod { get; set; }
    }
}
