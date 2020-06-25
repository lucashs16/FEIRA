using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.BLL
{
    public class Produtos
    {
        public List<MODEL.Produtos> Select()
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            return dalProduto.Select();
        }

        public MODEL.Produtos SelectByID(int id)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            return dalProduto.SelectByID(id);
        }

        public MODEL.Produtos SelectByDescricao(string descricao)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            return dalProduto.SelectByDescricao(descricao);
        }

        public void Insert (MODEL.Produtos produto)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            if(produto.descricao != String.Empty)
            dalProduto.Insert(produto);
        }

        public void Update (MODEL.Produtos produto)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            if(produto.descricao != String.Empty)
            dalProduto.Update(produto);
        }

        public void Delete (int idProduto)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            if (idProduto > 0)
            dalProduto.Delete(idProduto);
        }

        public float GetValorTotal(int produtoId, int quantidade)
        {
            DAL.Produtos dalProduto = new DAL.Produtos();
            MODEL.Produtos produto = dalProduto.SelectByID(produtoId);

            float valorTotal = 0;
            if (quantidade > produto.quantidade)
            {
                valorTotal = -1;
            }
            else
            {
                valorTotal = quantidade * produto.valor_venda;
            }

            return valorTotal;
        }

    }
}
