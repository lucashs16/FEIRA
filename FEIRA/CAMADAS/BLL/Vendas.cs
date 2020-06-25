using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.BLL
{
    public class Vendas
    {
        public List<MODEL.Vendas> Select()
        {
            DAL.Vendas dalVenda = new DAL.Vendas();
            return dalVenda.Select();
        }

        
        public void Insert(MODEL.Vendas venda)
        {
            DAL.Vendas dalVenda = new DAL.Vendas();
            DAL.Produtos dalProduto = new DAL.Produtos();


            MODEL.Produtos produto = new MODEL.Produtos();
            produto = dalProduto.SelectByID(venda.produtoId);

            venda.valorProduto = produto.valor_venda;

            produto.quantidade = produto.quantidade - venda.quantidadeCompra;

            dalProduto.Update(produto);

            dalVenda.Insert(venda);
        }


    }
}
