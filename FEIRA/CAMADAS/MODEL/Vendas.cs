using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.MODEL
{
    public class Vendas
    {
        public int id { get; set; }
        public string data { get; set; }
        public int produtoID { get; set; }
        public int clienteID { get; set; }
        public float quantidade { get; set; }
        public float total { get; set; }
    }
}
