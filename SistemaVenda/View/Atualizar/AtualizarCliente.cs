using SistemaVenda.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SistemaVenda.Classes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SistemaVenda.Forms
{
    public partial class AtualizarCliente : Form
    {
        public AtualizarCliente()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private readonly clienteDal dal = new clienteDal();
        private DataTable clienteDataTable;

        private void AtualizarCliente_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox4.Text.Length > 0)
            {
                int idCliente;

                if (int.TryParse(textBox1.Text, out idCliente))
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        MessageBox.Show("Preencha todos os campos antes de atualizar o cliente.");
                        return;
                    }

                    if (!NomeContemApenasLetrasOuEspacos(textBox2.Text))
                    {
                        MessageBox.Show("O nome do cliente deve conter apenas letras e espaços.",
                            "Alerta crítico",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(textBox3.Text, out int idade) || idade <= 0 || textBox3.Text.Length != 2 || idade < 18)
                    {
                        MessageBox.Show("Informe uma idade válida, não é permitido letras, nem valores negativos, mais de 2 dígitos, menor de 18 ou 0 nesse campo.");
                        return;
                    }

                    if (!long.TryParse(textBox4.Text, out long cpf) || cpf <= 0 || textBox4.Text.Length != 11)
                    {
                        MessageBox.Show("Informe um CPF válido com somente 11 números.");
                        return;
                    }

                    clienteDal dal = new clienteDal();
                    bool success = dal.Update(new cliente { id = idCliente, nome = textBox2.Text,
                        idade = int.TryParse(textBox3.Text, out int parsedIdade) ? parsedIdade : 0,
                        cpf = long.TryParse(textBox4.Text, out long parsedCpf) ? parsedCpf : 0 
                    });

                    if (success)
                    {
                        MessageBox.Show("Cliente atualizado com sucesso!");
                        button3_Click(sender, e);
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar o cliente. Verifique os dados e tente novamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Informe um ID válido para atualizar o cliente.");
                }
            } else
            {
                MessageBox.Show("Não é possível atualizar sem informações!",
                    "Alerta crítico",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
            }
        }

        private bool NomeContemApenasLetrasOuEspacos(string nome)
        {
            return Regex.IsMatch(nome, @"^[a-zA-Z\s]+$");
        }

        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            textBox1.Enabled = true;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int codigoCliente))
            {
                clienteDataTable = dal.FindById(codigoCliente);

                if (clienteDataTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = clienteDataTable;
                    dataGridView1.Visible = true;
                    textBox2.Text = clienteDataTable.Rows[0]["nome"].ToString();
                    textBox3.Text = clienteDataTable.Rows[0]["idade"].ToString();
                    textBox4.Text = clienteDataTable.Rows[0]["cpf"].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
