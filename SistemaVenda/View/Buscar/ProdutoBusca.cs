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
    public partial class ProdutoBusca : Form
    {
        public ProdutoBusca()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            produtoDal dal = new produtoDal();

            if (int.TryParse(textBox1.Text, out int codProduto))
            {
                if (codProduto <= 0)
                {
                    MessageBox.Show("O código do produto a ser procurado não pode ser um número negativo ou 0.");
                    dataGridView1.DataSource = null;
                }
                else
                {
                    DataTable dt = dal.FindById(codProduto);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado.");
                        dataGridView1.DataSource = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um ID válido para buscar o produto.");
                dataGridView1.DataSource = null;
            }
        }
    }
}
