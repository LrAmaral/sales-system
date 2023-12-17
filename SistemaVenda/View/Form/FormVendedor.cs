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
    public partial class FormVendedor : Form
    {
        public FormVendedor()
        {
            InitializeComponent();
            CenterToScreen();
        }

        static string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        user u = new user();
        userDal dal = new userDal();
        private void FormVendedor_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private bool NomeApenasLetras(string nome)
        {
            return nome.All(char.IsLetter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, insira o nome.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (textBox1.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("O nome não pode conter números.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!NomeApenasLetras(textBox1.Text))
                {
                    MessageBox.Show("O nome não pode conter caracteres especiais ou números.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBox4.Text))
                {
                    MessageBox.Show("Por favor, insira a senha.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!textBox4.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("A senha deve conter pelo menos 1 carácter.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Por favor, insira o papel.",
                        "Alerta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox4.Text.Length > 0)
                {
                    u.nome = textBox1.Text;
                    u.senha = textBox4.Text;
                    u.papel = textBox2.Text;

                    bool success = dal.Insert(u);
                    if (success)
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!");
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível realizar o cadastro!", "Alerta crítico!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Não é possível realizar o cadastro sem informações!",
                        "Alerta crítico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}");
            }
        }

        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar?",
                                                 "Cancelar cadastro",
                                                 MessageBoxButtons.YesNo);

            if (retorno == DialogResult.No)
            {
                return;
            }

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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
