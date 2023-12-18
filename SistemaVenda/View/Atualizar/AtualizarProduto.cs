using SistemaVenda.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using SistemaVenda.Classes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVenda.Forms
{
    public partial class AtualizarProduto : Form
    {
        public AtualizarProduto()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private readonly produtoDal dal = new produtoDal();
        private DataTable produtoDataTable;

        private void AtualizarProduto_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int codigoProduto))
            {
                produtoDataTable = dal.FindById(codigoProduto);

                if (produtoDataTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = produtoDataTable;
                    dataGridView1.Visible = true;
                    textBox2.Text = produtoDataTable.Rows[0]["marca"].ToString();
                    textBox3.Text = produtoDataTable.Rows[0]["modelo"].ToString();
                    textBox5.Text = produtoDataTable.Rows[0]["descricao"].ToString();
                    textBox4.Text = produtoDataTable.Rows[0]["preco"].ToString();
                    textBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.");
                    dataGridView1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Informe um ID válido para buscar o cliente.");
                dataGridView1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox4.Text.Length > 0)
            {

                int idProduto;

                if (int.TryParse(textBox1.Text, out idProduto))
                {

                    if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        MessageBox.Show("Preencha todos os campos antes de atualizar o produto.");
                        return;
                    }

                    if (!textBox3.Text.All(char.IsLetterOrDigit))
                    {
                        MessageBox.Show("O modelo deve conter apenas caracteres alfanuméricos.",
                            "Alerta crítico",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    decimal preco;

                    if (!Decimal.TryParse(textBox4.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out preco) || preco <= 0)
                    {
                        MessageBox.Show("Informe um preço válido.");
                        return;
                    }

                    produtoDal dal = new produtoDal();
                    bool success = dal.Update(new produto
                    {
                        id = idProduto,
                        marca = textBox2.Text,
                        modelo = textBox3.Text,
                        descricao = textBox5.Text,
                        preco = preco

                    }); ;

                    if (success)
                    {
                        MessageBox.Show("Produto atualizado com sucesso!");
                        button3_Click(sender, e);
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar o produto. Verifique os dados e tente novamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Informe um ID válido para atualizar o produto.");
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
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            textBox1.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
