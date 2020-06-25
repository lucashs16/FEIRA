using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.BLL
{
    public class Clientes
    {
        public List<MODEL.Clientes> Select()
        {
            DAL.Clientes dalCliente = new DAL.Clientes();
            return dalCliente.Select();
        }

        public MODEL.Clientes SelectByID(int id)
        {
            DAL.Clientes dalCliente = new DAL.Clientes();
            return dalCliente.SelectByID(id);
        }

        public MODEL.Clientes SelectByNome(string nome)
        {
            DAL.Clientes dalCliente = new DAL.Clientes();
            return dalCliente.SelectByNome(nome);
        }

        public void Insert(MODEL.Clientes cliente)
        {
            DAL.Clientes dalCliente = new DAL.Clientes();
            if (cliente.nome != String.Empty)
                dalCliente.Insert(cliente);
        }

        public void Update(MODEL.Clientes cliente)
        {
            DAL.Clientes dalCliente = new DAL.Clientes();
            if (cliente.nome != String.Empty)
                dalCliente.Update(cliente);
        }

        public void Delete(int idCliente)
        {
            DAL.Clientes dalCliente = new DAL.Clientes();
            if (idCliente > 0)
                dalCliente.Delete(idCliente);
        }
    }
}
