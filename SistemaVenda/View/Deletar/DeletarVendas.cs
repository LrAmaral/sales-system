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
    public partial class DeletarVendas : Form
    {
        public DeletarVendas()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    int vendaId = int.Parse(textBox1.Text);

                    vendaDal dal = new vendaDal();

                    bool success = dal.Delete(vendaId);

                    if (success)
                    {
                        MessageBox.Show("Venda excluída com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível excluir a venda. Verifique os dados e tente novamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Informe o ID da venda a ser excluída.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao excluir a venda: {ex.Message}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
