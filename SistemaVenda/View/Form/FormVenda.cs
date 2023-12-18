using SistemaVenda.Classes;
using SistemaVenda.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaVenda.Forms
{
    public partial class FormVenda : Form
    {
        public FormVenda()
        {
            InitializeComponent();
            CenterToScreen();
        }

        static string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        venda v = new venda();
        vendaDal dal = new vendaDal();
        private BindingSource bindingSource = new BindingSource();

        private void FormVenda_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox1.Text, out int codCliente))
                {
                    MessageBox.Show("Código do cliente inválido. Certifique-se de inserir um número inteiro válido.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (codCliente < 0)
                {
                    MessageBox.Show("Código do cliente não pode ser um número negativo.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!dal.ClienteExiste(codCliente))
                {
                    MessageBox.Show("Cliente não encontrado. Certifique-se de inserir um cliente existente.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox4.Text, out int codProduto))
                {
                    MessageBox.Show("Código do produto inválido. Certifique-se de inserir um número inteiro válido.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (codProduto < 0)
                {
                    MessageBox.Show("Código do produto não pode ser um número negativo.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!dal.ProdutoExiste(codProduto))
                {
                    MessageBox.Show($"Produto com código {codProduto} não encontrado. Certifique-se de inserir produtos existentes.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox2.Text, out int quantidade))
                {
                    MessageBox.Show("Quantidade inválida. Certifique-se de inserir um número inteiro válido.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (quantidade <= 0)
                {
                    MessageBox.Show("Quantidade não pode ser um número negativo ou 0.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }

                textBox1.Enabled = false;

                decimal precoProduto = dal.ObterTotalProduto(codProduto);

                v.codCliente = codCliente;
                v.data = DateTime.Now;

                ItemVenda novoItem = new ItemVenda
                {
                    codProduto = codProduto,
                    quantidade = quantidade,
                    totalItem = precoProduto * quantidade
                };

                v.Itens.Add(novoItem);

                AtualizarDadosDoGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao adicionar o item: {ex.ToString()}");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (v.Itens.Count == 0)
                {
                    MessageBox.Show("A venda não possui itens. Adicione pelo menos um item antes de finalizar.");
                    return;
                }

                vendaDal dal = new vendaDal();
                bool success = dal.Insert(v);
                if (success)
                {
                    MessageBox.Show("Venda cadastrada com sucesso!");
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível cadastrar a venda. Verifique os dados e tente novamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao cadastrar a venda: {ex.ToString()}");
            }
        }

        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            v = new venda();

            AtualizarDadosDoGridView();

            textBox1.Enabled = true;
        }

        private void AtualizarDadosDoGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Código do Produto");
            dt.Columns.Add("Quantidade");
            dt.Columns.Add("Total do Item");

            var groupedItems = v.Itens.GroupBy(item => item.codProduto);

            foreach (var group in groupedItems)
            {
                decimal totalItem = group.Sum(item => item.totalItem);

                DataRow row = dt.Rows.Add();
                row["Código do Produto"] = group.Key;
                row["Quantidade"] = group.Sum(item => item.quantidade);
                row["Total do Item"] = totalItem;
            }

            bindingSource.DataSource = dt;

            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vendaDal dal = new vendaDal();
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0 && textBox4.Text.Length > 0)
            {
                DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar?",
                                                   "Cancelar venda",
                                                   MessageBoxButtons.YesNo);

                if (retorno == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                if (v.Itens.Count == 0)
                {
                    MessageBox.Show("A compra ainda não foi iniciada.",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int codigoProduto = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Código do Produto"].Value);

                    v.Itens.RemoveAll(item => item.codProduto == codigoProduto);

                    AtualizarDadosDoGridView();
                }
                else
                {
                    MessageBox.Show("Selecione uma linha para excluir o produto da venda.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao excluir o produto da venda: {ex.ToString()}");
            }
        }
    }
}
