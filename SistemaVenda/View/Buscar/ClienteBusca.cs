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

namespace SistemaVenda
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public void ExibirCentralizadoMenuCadastro()
        {
            MdiParent = this.ParentForm;
            StartPosition = FormStartPosition.CenterScreen;
            Show();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            clienteDal dal = new clienteDal();

            if (int.TryParse(textBox1.Text, out int codigoCliente))
            {
                DataTable dt = dal.FindById(codigoCliente);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.");
                    dataGridView1.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("Informe um ID válido para buscar o cliente.");
                dataGridView1.DataSource = null;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
