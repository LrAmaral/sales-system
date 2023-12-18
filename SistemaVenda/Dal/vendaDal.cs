using SistemaVenda.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaVenda.Dal
{
    internal class vendaDal
    {
        static string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        #region Selecionar dados do banco de dados
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_itemVenda";
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
        public DataTable FindById(int codVenda)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    string sql = "SELECT * FROM tbl_Venda WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", codVenda);

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

        #region localizar por id item venda
        public List<ItemVenda> FindByIdItemVenda(int codVenda)
        {
            List<ItemVenda> itensVenda = new List<ItemVenda>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    string sql = "SELECT * FROM tbl_ItemVenda WHERE codVenda = @codVenda";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@codVenda", codVenda);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ItemVenda item = new ItemVenda
                                {
                                    codVenda = Convert.ToInt32(reader["codVenda"]),
                                    codProduto = Convert.ToInt32(reader["codProduto"]),
                                    quantidade = Convert.ToInt32(reader["quantidade"]),
                                    totalItem = Convert.ToDecimal(reader["totalItem"])
                                };
                                itensVenda.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return itensVenda;
        }
        #endregion

        #region adicionar dados no banco de dados

        public bool Insert(venda venda)
        {
            bool isSucesso = false;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                           
                            foreach (var item in venda.Itens)
                            {
                                if (!ProdutoExiste(item.codProduto))
                                {
                                    MessageBox.Show($"Produto com código {item.codProduto} não encontrado. Certifique-se de inserir produtos existentes.");
                                }
                            }

                            decimal totalVenda = venda.Itens.Sum(item => item.totalItem);

                            string sql = "INSERT INTO tbl_Venda (codCliente, data) VALUES (@codCliente, @data); SELECT SCOPE_IDENTITY();";
                            using (SqlCommand cmd = new SqlCommand(sql, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@codCliente", venda.codCliente);
                                cmd.Parameters.AddWithValue("@data", DateTime.Now);

                                int vendaId = Convert.ToInt32(cmd.ExecuteScalar());

                                foreach (var item in venda.Itens)
                                {
                                    string itemSql = "INSERT INTO tbl_ItemVenda (codVenda, codProduto, quantidade, totalItem) VALUES (@codVenda, @codProduto, @quantidade, @totalItem)";
                                    using (SqlCommand itemCmd = new SqlCommand(itemSql, con, transaction))
                                    {
                                        itemCmd.Parameters.AddWithValue("@codVenda", vendaId);
                                        itemCmd.Parameters.AddWithValue("@codProduto", item.codProduto);
                                        itemCmd.Parameters.AddWithValue("@quantidade", item.quantidade);
                                        itemCmd.Parameters.AddWithValue("@totalItem", item.totalItem);

                                        itemCmd.ExecuteNonQuery();
                                    }
                                }

                                transaction.Commit();
                                isSucesso = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                transaction?.Rollback();
                            }
                            catch { }

                            throw new Exception($"Erro ao inserir venda: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao abrir a conexão: {ex.Message}");
            }

            return isSucesso;
        }

        public bool ClienteExiste(int codCliente)
        {
            SqlTransaction transaction = null;
            SqlConnection con = new SqlConnection(_connectionString);
            string sql = "SELECT COUNT(*) FROM tbl_Cliente WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, con, transaction);
            cmd.Parameters.AddWithValue("@id", codCliente);

            con.Open();
            int count = (int)cmd.ExecuteScalar();

            return count > 0;
        }

        public bool ProdutoExiste(int codProduto)
        {
            SqlTransaction transaction = null;
            SqlConnection con = new SqlConnection(_connectionString);
            string sql = "SELECT COUNT(*) FROM tbl_Produto WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, con, transaction);
            cmd.Parameters.AddWithValue("@id", codProduto);

            con.Open();
            int count = (int)cmd.ExecuteScalar();

            return count > 0;
        }

        public decimal ObterTotalProduto(int codProduto)
        {
            try
            {
                string sql = "SELECT preco FROM tbl_Produto WHERE id = @id";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", codProduto);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        decimal precoProduto = reader.GetDecimal(0);
                        reader.Close();

                        return precoProduto;
                    }
                    else
                    {
                        throw new Exception($"Informações do produto com código {codProduto} não foram encontradas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter o total do produto: {ex.Message}");
                return 0;
            }
        }
        #endregion

        #region atualizar dados no banco de dados

        public bool Update(venda v)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);
            SqlTransaction transaction = null;

            try
            {
                con.Open();
                transaction = con.BeginTransaction();

                foreach (ItemVenda item in v.Itens)
                {
                    string selectPrecoSql = "SELECT preco FROM tbl_Produto WHERE id = @idProduto";
                    using (SqlCommand selectPrecoCmd = new SqlCommand(selectPrecoSql, con, transaction))
                    {
                        selectPrecoCmd.Parameters.AddWithValue("@idProduto", item.codProduto);
                        item.valorUnitario = Convert.ToDecimal(selectPrecoCmd.ExecuteScalar());
                    }

                    if (item.quantidade == 0)
                    {
                        MessageBox.Show($"O produto {item.codProduto} foi excluído da venda. Verifique.");

                        string deleteItemSql = "DELETE FROM tbl_ItemVenda WHERE codProduto = @id AND codVenda = @codVenda";
                        SqlCommand deleteItemCmd = new SqlCommand(deleteItemSql, con, transaction);
                        deleteItemCmd.Parameters.AddWithValue("@id", item.codProduto);
                        deleteItemCmd.Parameters.AddWithValue("@codVenda", item.codVenda);
                        deleteItemCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string itemSql = "UPDATE tbl_ItemVenda SET quantidade = @quantidade, totalItem = @totalItem WHERE codProduto = @id AND codVenda = @codVenda";
                        SqlCommand itemCmd = new SqlCommand(itemSql, con, transaction);
                        itemCmd.Parameters.AddWithValue("@id", item.codProduto);
                        itemCmd.Parameters.AddWithValue("codVenda", item.codVenda);
                        itemCmd.Parameters.AddWithValue("@quantidade", item.quantidade);
                        itemCmd.Parameters.AddWithValue("@totalItem", item.valorUnitario * item.quantidade);
                        itemCmd.ExecuteNonQuery();
                    }
                }

                if (!v.Itens.Any())
                {
                    string deleteVendaSql = "DELETE FROM tbl_Venda WHERE id = @idVenda";
                    SqlCommand deleteVendaCmd = new SqlCommand(deleteVendaSql, con, transaction);
                    deleteVendaCmd.Parameters.AddWithValue("@idVenda", v.id);
                    deleteVendaCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                isSucesso = true;
            }
            catch (Exception ex)
            {
                try
                {
                    transaction?.Rollback();
                }
                catch { }

                MessageBox.Show($"Erro ao atualizar a venda: {ex.Message}");
            }
            finally
            {
                con.Close();
            }

            return isSucesso;
        }
        #endregion

        #region Excluir dados no banco de dados
        public bool Delete(int codVenda)
        {
            bool isSucesso = false;
            SqlConnection con = new SqlConnection(_connectionString);
            SqlTransaction transaction = null;

            try
            {
                con.Open();
                transaction = con.BeginTransaction();

                string ItensSql = "DELETE FROM tbl_ItemVenda WHERE codVenda = @codVenda";
                SqlCommand ItensCmd = new SqlCommand(ItensSql, con, transaction);
                ItensCmd.Parameters.AddWithValue("@codVenda", codVenda);
                ItensCmd.ExecuteNonQuery();

                string VendaSql = "DELETE FROM tbl_Venda WHERE id = @id";
                SqlCommand VendaCmd = new SqlCommand(VendaSql, con, transaction);
                VendaCmd.Parameters.AddWithValue("@id", codVenda);
                VendaCmd.ExecuteNonQuery();

                transaction.Commit();
                isSucesso = true;
            }
            catch (Exception ex)
            {
                try
                {
                    transaction?.Rollback();
                }
                catch { }

                MessageBox.Show($"Erro ao excluir a venda: {ex.Message}");
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
