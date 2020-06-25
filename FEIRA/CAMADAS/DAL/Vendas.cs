using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.DAL
{
    public class Vendas
    {
        private string strCon = CAMADAS.DAL.Conexao.getConexao();

        public List<MODEL.Vendas> Select()
        {
            List<MODEL.Vendas> lstVendas = new List<MODEL.Vendas>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Vendas;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    CAMADAS.MODEL.Vendas venda = new MODEL.Vendas();
                    venda.id = Convert.ToInt32(dados["id"].ToString());
                    venda.produtoId = Convert.ToInt32(dados["produtoId"].ToString());
                    venda.clienteId = Convert.ToInt32(dados["clienteId"].ToString());
                    venda.quantidadeCompra = Convert.ToInt32(dados["quantidadeCompra"].ToString());
                    venda.valorProduto = Convert.ToSingle(dados["valorProduto"].ToString());
                    venda.dataVenda = Convert.ToDateTime(dados["dataVenda"].ToString());
                    
                    lstVendas.Add(venda);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Vendas...");
            }
            finally
            {
                conexao.Close();
            }

            return lstVendas;
        }


        public void Insert(MODEL.Vendas venda)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Vendas VALUES (@produtoId, @clienteId, @quantidadeCompra, @valorProduto, @dataVenda);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@produtoId", venda.produtoId);
            cmd.Parameters.AddWithValue("@clienteId", venda.clienteId);
            cmd.Parameters.AddWithValue("@quantidadeCompra", venda.quantidadeCompra);
            cmd.Parameters.AddWithValue("@valorProduto", venda.valorProduto);
            cmd.Parameters.AddWithValue("@dataVenda", venda.dataVenda);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na inserção de Vendas...");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
