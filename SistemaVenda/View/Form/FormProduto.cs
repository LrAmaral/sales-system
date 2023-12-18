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

namespace SistemaVenda
{
    public partial class FormProduto : Form
    {
        public FormProduto()
        {
            InitializeComponent();
            CenterToScreen();
        }

        static string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        produto p = new produto();
        produtoDal dal = new produtoDal();

        private void MenuProduto_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar?",
                                                  "Cancelar venda",
                                                  MessageBoxButtons.YesNo);

            if (retorno == DialogResult.No)
            {
                return;
            }

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LimparCampos()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, insira a marca.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Por favor, insira o modelo.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!textBox2.Text.All(char.IsLetterOrDigit))
                {
                    MessageBox.Show("O modelo deve conter apenas caracteres alfanuméricos.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Por favor, insira a descrição.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("Por favor, insira o preço.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                p.marca = textBox1.Text;
                p.modelo = textBox2.Text;
                p.descricao = textBox3.Text;
            
                if (decimal.TryParse(textBox4.Text.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out decimal preco))
                {
                    if (preco <= 0)
                    {
                        MessageBox.Show("O preço deve ser um número maior que zero.",
                            "Alerta crítico",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    p.preco = preco;
                }
                else
                {
                    MessageBox.Show("Preço inválido. Certifique-se de inserir um valor numérico válido para o Preço.",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }

                bool success = dal.Insert(p);
                if (success)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível realizar o cadastro!",
                        "Alerta crítico!",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox4.Text.Length > 0)
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
    }
}
