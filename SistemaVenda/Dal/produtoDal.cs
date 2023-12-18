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
    internal class produtoDal
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region selecionar dados do banco de dados
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_Produto";
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
        public DataTable FindById(int codProduto)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    string sql = "SELECT * FROM tbl_Produto WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", codProduto);

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
        public bool Insert(produto p)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);

            try
            {
                if (p.preco < 0)
                {
                    MessageBox.Show("O preço não pode ser um número negativo.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return false;
                }

                String sql = "INSERT INTO tbl_Produto(marca, modelo, descricao, preco) VALUES (@marca, @modelo, @descricao, @preco)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@marca", p.marca);
                cmd.Parameters.AddWithValue("@modelo", p.modelo);
                cmd.Parameters.AddWithValue("@descricao", p.descricao);
                cmd.Parameters.AddWithValue("@preco", p.preco);

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                isSucesso = rows > 0;
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

        #region atualizar dados no banco de dados
        public bool Update(produto p)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);
            try
            {
                String sql = "UPDATE tbl_Produto SET marca = @marca, modelo = @modelo, descricao = @descricao, preco = @preco WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", p.id);
                cmd.Parameters.AddWithValue("@marca", p.marca);
                cmd.Parameters.AddWithValue("@modelo", p.modelo);
                cmd.Parameters.AddWithValue("@descricao", p.descricao);
                cmd.Parameters.AddWithValue("@preco", p.preco);

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

        #region excluir dados no banco de dados
        public bool Delete(int codProduto)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);
            SqlTransaction transaction = null;

            try
            {
                if (ProdutoNaVenda(codProduto))
                {
                    MessageBox.Show("Não é possível excluir o produto porque existem vendas associadas a ele.");
                }

                String sql = "DELETE FROM tbl_Produto WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", codProduto);

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

        public bool ProdutoNaVenda(int codProduto)
        {
            SqlConnection con = new SqlConnection(_connectionString);

            try
            {
                con.Open();

                string sql = "SELECT COUNT(*) FROM tbl_ItemVenda WHERE codProduto = @codProduto";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codProduto", codProduto);

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar vendas associadas ao produto: {ex.Message}");
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
