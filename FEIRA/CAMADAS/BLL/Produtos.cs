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
    }
}
