using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.DAL
{
    public class Produtos
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Produtos> Select()
        {
            List<MODEL.Produtos> lstProdutos = new List<MODEL.Produtos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Produtos;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Produtos produto = new MODEL.Produtos();
                    produto.id = Convert.ToInt32(dados["id"].ToString());
                    produto.descricao = dados["descricao"].ToString();
                    produto.valor_venda = Convert.ToSingle(dados["valor_venda"].ToString());
                    produto.valor_compra = Convert.ToSingle(dados["valor_compra"].ToString());
                    produto.vencimento = dados["vencimento"].ToString();
                    produto.fornecedor = dados["fornecedor"].ToString();
                    produto.quantidade = Convert.ToInt32(dados["quantidade"].ToString());

                    lstProdutos.Add(produto);
                }
            }
            catch
            {
                Console.WriteLine("Erro na consulta de Produtos...");
            }
            finally
            {
                conexao.Close();
            }

            return lstProdutos;
        }

        public void Insert (MODEL.Produtos produto)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Produtos VALUES (@descricao, @valor_venda, @valor_compra, @vencimento, @fornecedor, @quantidade);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@descricao", produto.descricao);
            cmd.Parameters.AddWithValue("@valor_venda", produto.valor_venda);
            cmd.Parameters.AddWithValue("@valor_compra", produto.valor_compra);
            cmd.Parameters.AddWithValue("@vencimento", produto.vencimento);
            cmd.Parameters.AddWithValue("@fornecedor", produto.fornecedor);
            cmd.Parameters.AddWithValue("@quantidade", produto.quantidade);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de Produtos...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update (MODEL.Produtos produto)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE Produtos SET descricao=@descricao, valor_venda=@valor_venda, valor_compra=@valor_compra, vencimento=@vencimento, fornecedor=@fornecedor, quantidade=@quantidade WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", produto.id);
            cmd.Parameters.AddWithValue("@descricao", produto.descricao);
            cmd.Parameters.AddWithValue("@valor_venda", produto.valor_venda);
            cmd.Parameters.AddWithValue("@valor_compra", produto.valor_compra);
            cmd.Parameters.AddWithValue("@vencimento", produto.vencimento);
            cmd.Parameters.AddWithValue("@fornecedor", produto.fornecedor);
            cmd.Parameters.AddWithValue("@quantidade", produto.quantidade);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Produtos...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete (int idProduto)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM Produtos WHERE id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", idProduto);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na romoção de Produtos");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
