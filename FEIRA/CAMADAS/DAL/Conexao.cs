using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.DAL
{
    public class Conexao
    {
        public static string getConexao()
        {
            return @"Data Source=.\SQLEXPRESS;Initial Catalog=FEIRA;Integrated Security=True";
        }
    }
}
