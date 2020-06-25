using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FEIRA.CAMADAS.DAL
{
    public class Clientes
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Clientes> Select()
        {
            List<MODEL.Clientes> lstClientes = new List<MODEL.Clientes>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Clientes;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Clientes cliente = new MODEL.Clientes();
                    cliente.id = Convert.ToInt32(dados["id"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.rua = dados["rua"].ToString();
                    cliente.numero = Convert.ToInt32(dados["numero"].ToString());
                    cliente.cidade = dados["cidade"].ToString();
                    cliente.estado = dados["estado"].ToString();
                    cliente.cpf = dados["cpf"].ToString();
                    cliente.telefone = dados["telefone"].ToString();
                    cliente.email = dados["email"].ToString();
                    cliente.nascimento = Convert.ToDateTime(dados["nascimento"]);

                    lstClientes.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Clientes...");
            }
            finally
            {
                conexao.Close();
            }

            return lstClientes;
        }

        public MODEL.Clientes SelectByID(int id)
        {
            MODEL.Clientes cliente = new MODEL.Clientes();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Clientes WHERE id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dados.Read())
                {
                    cliente.id = Convert.ToInt32(dados["id"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.rua = dados["rua"].ToString();
                    cliente.numero = Convert.ToInt32(dados["numero"].ToString());
                    cliente.cidade = dados["cidade"].ToString();
                    cliente.estado = dados["estado"].ToString();
                    cliente.cpf = dados["cpf"].ToString();
                    cliente.telefone = dados["telefone"].ToString();
                    cliente.email = dados["email"].ToString();
                    cliente.nascimento = Convert.ToDateTime(dados["nascimento"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Clientes por ID...");
            }
            finally
            {
                conexao.Close();
            }

            return cliente;
        }

        public MODEL.Clientes SelectByNome(string nome)
        {
            MODEL.Clientes cliente = new MODEL.Clientes();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Clientes WHERE(nome LIKE @nome)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dados.Read())
                {
                    cliente.id = Convert.ToInt32(dados["id"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.rua = dados["rua"].ToString();
                    cliente.numero = Convert.ToInt32(dados["numero"].ToString());
                    cliente.cidade = dados["cidade"].ToString();
                    cliente.estado = dados["estado"].ToString();
                    cliente.cpf = dados["cpf"].ToString();
                    cliente.telefone = dados["telefone"].ToString();
                    cliente.email = dados["email"].ToString();
                    cliente.nascimento = Convert.ToDateTime(dados["nascimento"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Clientes por Nome...");
            }
            finally
            {
                conexao.Close();
            }

            return cliente;
        }

        public void Insert (MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Clientes VALUES (@nome, @rua, @numero, @cidade, @estado, @cpf, @telefone, @email, @nascimento);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@rua", cliente.rua);
            cmd.Parameters.AddWithValue("@numero", cliente.numero);
            cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
            cmd.Parameters.AddWithValue("@estado", cliente.estado);
            cmd.Parameters.AddWithValue("@cpf", cliente.cpf);
            cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
            cmd.Parameters.AddWithValue("@email", cliente.email);
            cmd.Parameters.AddWithValue("@nascimento", cliente.nascimento);

            
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na inserção de clientes...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update (MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE Clientes SET nome=@nome, rua=@rua, numero=@numero, cidade=@cidade, estado=@estado, cpf=@cpf, telefone=@telefone, email=@email, nascimento=@nascimento WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cliente.id);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@rua", cliente.rua);
            cmd.Parameters.AddWithValue("@numero", cliente.numero);
            cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
            cmd.Parameters.AddWithValue("@estado", cliente.estado);
            cmd.Parameters.AddWithValue("@cpf", cliente.cpf);
            cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
            cmd.Parameters.AddWithValue("@email", cliente.email);
            cmd.Parameters.AddWithValue("@nascimento", cliente.nascimento);


            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de clientes...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete (int idCliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM Clientes WHERE id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", idCliente);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na romoção de Clientes");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
