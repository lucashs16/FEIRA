using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.CAMADAS.DAL
{
    public class TipoProdutos
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.TipoProdutos> Select()
        {
            List<MODEL.TipoProdutos> lstTipoProduto = new List<MODEL.TipoProdutos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM TipoProdutos;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.TipoProdutos tipoProduto = new MODEL.TipoProdutos();
                    tipoProduto.id = Convert.ToInt32(dados["id"].ToString());
                    tipoProduto.descricao = dados["descricao"].ToString();
                    lstTipoProduto.Add(tipoProduto);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Tipos de Produto...");
            }
            finally
            {
                conexao.Close();
            }

            return lstTipoProduto;
        }

        public MODEL.TipoProdutos SelectByID(int id)
        {
            MODEL.TipoProdutos tipoProduto = new MODEL.TipoProdutos();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM TipoProdutos WHERE id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dados.Read())
                {
                    tipoProduto.id = Convert.ToInt32(dados["id"].ToString());
                    tipoProduto.descricao = dados["descricao"].ToString();
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Produto por ID...");
            }
            finally
            {
                conexao.Close();
            }

            return tipoProduto;
        }

       

        public void Insert(MODEL.TipoProdutos tipoProduto)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO TipoProdutos VALUES (@descricao);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@descricao", tipoProduto.descricao);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na inserção de tipo de produto...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(MODEL.TipoProdutos tipoProdutos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE TipoProdutos SET descricao=@descricao WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", tipoProdutos.id);
            cmd.Parameters.AddWithValue("@descricao", tipoProdutos.descricao);
            
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de tipo de produto...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(int idCliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM TipoProdutos WHERE id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", idCliente);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção de tipo de produto");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
