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
    public partial class VendedorBusca : Form
    {
        public VendedorBusca()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar?",
                                                  "Cancelar cadastro",
                                                  MessageBoxButtons.YesNo);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userDal dal = new userDal();

            if (int.TryParse(textBox1.Text, out int codUsuario))
            {
                if (codUsuario <= 0)
                {
                    MessageBox.Show("O código do usuário a ser procurado não pode ser um número negativo ou 0.");
                    dataGridView1.DataSource = null;
                }
                else
                {
                    DataTable dt = dal.FindById(codUsuario);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Usuario não encontrado.");
                        dataGridView1.DataSource = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um ID válido para buscar o usuário.");
                dataGridView1.DataSource = null;
            }
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VendedorBusca_Load(object sender, EventArgs e)
        {

        }
    }
}
