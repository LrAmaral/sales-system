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
    internal class userDal
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region localizar por nome e senha
        public DataTable FindByNomeAndSenha(string nome, string senha)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_Usuario WHERE Nome = @nome AND Senha = @senha";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@senha", senha);

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

        #region selecionar dados do banco de dados
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            DataTable dt = new DataTable();
            try
            {
                String sql = "Select * from tbl_Usuario";
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
        public DataTable FindById(int codUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    string sql = "SELECT * FROM tbl_Usuario WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", codUsuario);

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

        #region adicionar dados no banco de dados
        public bool Insert(user u)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);

            try
            {
                if (string.IsNullOrWhiteSpace(u.nome))
                {
                    MessageBox.Show("Nome não pode estar vazio. Insira um nome válido.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(u.senha))
                {
                    MessageBox.Show("Senha não pode estar vazia. Insira uma senha válida.");
                    return false;
                }

                if (NomeExistente(u.nome))
                {
                    MessageBox.Show("Nome já existe. Escolha um nome diferente.");
                    return false;
                }

                if (NomeComNumeros(u.nome))
                {
                    MessageBox.Show("O nome não pode conter números.");
                    return false;
                }

                if (NomeComCaracteresEspeciais(u.nome))
                {
                    MessageBox.Show("O nome não pode conter caracteres especiais.");
                    return false;
                }

                if (!PapelValido(u.papel))
                {
                    MessageBox.Show("Papel inválido. Escolha 'vendedor' ou 'gerente'.");
                    return false;
                }

                if (NomeComNumeros(u.nome))
                {
                    MessageBox.Show("O nome não pode conter números.");
                    return false;
                }

                String sql = "INSERT INTO tbl_Usuario(nome, senha, papel) VALUES (@nome,@senha,@papel)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@papel", u.papel);

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

        private bool PapelValido(string papel)
        {
            string[] papeisValidos = { "vendedor", "gerente" };
            return papeisValidos.Contains(papel.ToLower());
        }

        private bool NomeExistente(string nome)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string sql = "SELECT COUNT(*) FROM tbl_Usuario WHERE nome = @nome";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool NomeComNumeros(string nome)
        {
            return nome.Any(char.IsDigit);
        }

        private bool NomeComCaracteresEspeciais(string nome)
        {
            return nome.Any(c => !char.IsLetterOrDigit(c));
        }
        #endregion

        #region atualizar dados no banco de dados
        public bool Update(user u)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);

            try
            {

                if (NomeComNumeros(u.nome))
                {
                    MessageBox.Show("O nome não pode conter números.");
                    return false;
                }

                if (NomeComCaracteresEspeciais(u.nome))
                {
                    MessageBox.Show("O nome não pode conter caracteres especiais.");
                    return false;
                }

                string nomeAtual = NomeAtual(u.id);

                if (nomeAtual != u.nome)
                {
                    if (NomeExistente(u.nome))
                    {
                        MessageBox.Show("Nome já existe. Escolha um nome diferente.");
                        return false;
                    }
                }

                if (!PapelValido(u.papel))
                {
                    MessageBox.Show("Papel inválido. Escolha 'vendedor' ou 'gerente'.");
                    return false;
                }

                String sql = "UPDATE tbl_Usuario SET nome = @nome, senha = @senha, papel = @papel WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", u.id);
                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@papel", u.papel);

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

        private string NomeAtual(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string sql = "SELECT nome FROM tbl_Usuario WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    con.Open();
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
        }
        #endregion

        #region deletar dados no banco de dados
        public bool Delete(int codVendedor)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);
            try
            {
                String sql = "DELETE FROM tbl_Usuario WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", codVendedor);

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
    }
}
