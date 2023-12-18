using SistemaVenda.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.Dal
{
    internal class clienteDal
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
      
        #region selecionar dados do banco de dados
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_Cliente";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            finally 
            { 
                con.Close();
            }
            return dt;
        }


        #endregion

        #region localizar por id
        public DataTable FindById(int codCliente)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    string sql = "SELECT * FROM tbl_Cliente WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", codCliente);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }
        #endregion

        #region cadastrando dados no banco de dados
        public bool Insert(cliente u)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);
            try
            {
                if (NomeComNumeros(u.nome))
                {
                    MessageBox.Show("O nome do cliente não pode conter números.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return false;
                }

                if (u.idade < 0)
                {
                    MessageBox.Show("A idade não pode ser um número negativo.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return false;
                }

                String sql = "INSERT INTO tbl_Cliente(nome, idade, cpf) VALUES (@nome,@idade,@cpf)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@idade", u.idade);
                cmd.Parameters.AddWithValue("@cpf", u.cpf);

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucesso = true;
                }
                else
                {
                    isSucesso = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir cliente: {ex.Message}");
            }
            finally
            {
                con.Close();
            }
            return isSucesso;
        }

        private bool NomeComNumeros(string nome)
        {
            return nome.Any(char.IsDigit);
        }
        #endregion

        #region atualizar dados no banco de dados
        public bool Update(cliente u)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);

            try
            {
                String sql = "UPDATE tbl_Cliente SET nome = @nome, idade = @idade, cpf = @cpf WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", u.id);
                cmd.Parameters.AddWithValue("@nome",u.nome);
                cmd.Parameters.AddWithValue("@idade", u.idade);
                cmd.Parameters.AddWithValue("@cpf", u.cpf);

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucesso = true;
                }
                else
                {
                    isSucesso = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return isSucesso;
        }
        #endregion

        #region deletar dados no banco de dados
        public bool Delete(int codCliente)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);
            SqlTransaction transaction = null;

            try
            {
                if (ClientesNaVenda(codCliente))
                {
                    MessageBox.Show("Não é possível excluir o cliente porque existem vendas associadas a ele.");
                }

                String sql = "DELETE FROM tbl_Cliente WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", codCliente);

                con.Open();
                transaction = con.BeginTransaction();
                cmd.Transaction = transaction;

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSucesso = true;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    transaction?.Rollback();
                }
                catch { }

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return isSucesso;
        }

        public bool ClientesNaVenda(int codCliente)
        {
            SqlConnection con = new SqlConnection(_connectionString);

            try
            {
                con.Open();

                string sql = "SELECT COUNT(*) FROM tbl_Venda WHERE codCliente = @codCliente";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codCliente", codCliente);

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar vendas associadas ao cliente: {ex.Message}");
                return true;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}
