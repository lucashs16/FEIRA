using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.MODEL
{
    public class Vendas
    {
        public int id { get; set; }
        public int produtoId { get; set; }
        public int clienteId { get; set; }
        public int quantidadeCompra { get; set; }
        public float valorProduto { get; set; }
        public DateTime dataVenda { get; set; }
    }
}
