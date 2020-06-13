using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.MODEL
{
    public class Produtos
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public float valor_venda { get; set; }
        public float valor_compra { get; set; }
        public string vencimento { get; set; }
        public string fornecedor { get; set; }
        public int quantidade { get; set; }
    }
}
