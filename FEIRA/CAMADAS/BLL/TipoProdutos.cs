using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.BLL
{
    public class TipoProdutos
    {
        public List<MODEL.TipoProdutos> Select()
        {
            DAL.TipoProdutos dalTipoProduto = new DAL.TipoProdutos();
            return dalTipoProduto.Select();
        }

        public MODEL.TipoProdutos SelectByID(int id)
        {
            DAL.TipoProdutos dalTipoProduto = new DAL.TipoProdutos();
            return dalTipoProduto.SelectByID(id);
        }

        public void Insert(MODEL.TipoProdutos tipoProduto)
        {
            DAL.TipoProdutos dalTipoProduto = new DAL.TipoProdutos();
            dalTipoProduto.Insert(tipoProduto);
        }

        public void Update(MODEL.TipoProdutos cliente)
        {
            DAL.TipoProdutos dalTipoProduto = new DAL.TipoProdutos();
            dalTipoProduto.Update(cliente);
        }

        public void Delete(int idProduto)
        {
            DAL.TipoProdutos dalTipoProduto = new DAL.TipoProdutos();
            dalTipoProduto.Delete(idProduto);
        }
    }
}
