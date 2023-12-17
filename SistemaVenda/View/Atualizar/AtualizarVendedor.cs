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

namespace SistemaVenda.Forms
{
    public partial class AtualizarVendedor : Form
    {
        public AtualizarVendedor()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private readonly userDal dal = new userDal();
        private DataTable userDataTable;

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox4.Text.Length > 0)
            {
                int idUser;

                if (int.TryParse(textBox1.Text, out idUser))
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        MessageBox.Show("Preencha todos os campos antes de atualizar o usuário.");
                        return;
                    }

                    userDal dal = new userDal();
                    bool success = dal.Update(new user
                    {
                        id = idUser,
                        nome = textBox2.Text,
                        senha = textBox3.Text,
                        papel = textBox4.Text,
                    });

                    if (success)
                    {
                        MessageBox.Show("Usuário atualizado com sucesso!");
                        button3_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar o usuário. Verifique os dados e tente novamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Informe um ID válido para atualizar o usuário."); ;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int codigoUser))
            {
                userDataTable = dal.FindById(codigoUser);

                if (userDataTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = userDataTable;
                    dataGridView1.Visible = true;
                    textBox2.Text = userDataTable.Rows[0]["nome"].ToString();
                    textBox3.Text = userDataTable.Rows[0]["senha"].ToString();
                    textBox4.Text = userDataTable.Rows[0]["papel"].ToString();
                    dataGridView1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.");
                    dataGridView1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Informe um ID válido para buscar o usuário.");
                dataGridView1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AtualizarVendedor_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            
        }
    }
}
