using SistemaVenda.Classes;
using SistemaVenda.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaVenda.Forms
{
    public partial class AtualizarVenda : Form
    {
        public AtualizarVenda()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private readonly vendaDal dal = new vendaDal();
        private DataTable vendaDataTable;

        private void AtualizarVenda_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int codigoVenda))
            {
                List<ItemVenda> itensVendaEncontrados = dal.FindByIdItemVenda(codigoVenda);

                if (itensVendaEncontrados.Count > 0)
                {
                    dataGridView1.DataSource = itensVendaEncontrados;
                    dataGridView1.Visible = true;
                    textBox1.Enabled = false;


                    if (dataGridView1.Columns.Contains("ValorUnitario"))
                    {
                        dataGridView1.Columns["ValorUnitario"].Visible = false;
                    }

                }
                else
                {
                    MessageBox.Show("Itens de venda não encontrados para a venda especificada ou a venda não existe.");
                    dataGridView1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Informe um ID válido para buscar os itens da venda.");
                dataGridView1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox4.Text.Length > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedRows[0].Index;

                    if (int.TryParse(dataGridView1.Rows[rowIndex].Cells["codVenda"].Value.ToString(), out int codVenda))
                    {
                        if (string.IsNullOrWhiteSpace(textBox4.Text))
                        {
                            MessageBox.Show("Preencha todos os campos antes de atualizar a venda.");
                            return;
                        }

                        if (!int.TryParse(textBox4.Text, out int novaQuantidade) || novaQuantidade < 0)
                        {
                            MessageBox.Show("Informe uma quantidade válida.");
                            return;
                        }

                        vendaDal dal = new vendaDal();
                        List<ItemVenda> itensVenda = dal.FindByIdItemVenda(codVenda);

                        if (itensVenda != null && itensVenda.Count > 0)
                        {
                            itensVenda[rowIndex].quantidade = novaQuantidade;

                            bool success = dal.Update(new venda { Itens = itensVenda });

                            if (success)
                            {
                                MessageBox.Show("Venda atualizada com sucesso!");
                                button3_Click(sender, e);
                                LimparCampos();
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível atualizar a venda. Verifique os dados e tente novamente.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao obter o código da venda selecionada.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione uma venda para atualizar.");
                }
            }
            else
            {
                MessageBox.Show("Não é possível atualizar sem informações!",
                    "Alerta crítico",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
            }
        }

        private void LimparCampos()
        {
            textBox1.Clear();
            textBox4.Clear();

            textBox1.Enabled = true;
            dataGridView1.DataSource = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
