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
    public partial class DeletarVendedor : Form
    {
        public DeletarVendedor()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void DeletarVendedor_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    int codVendedor = int.Parse(textBox1.Text);

                    userDal dal = new userDal();

                    bool success = dal.Delete(codVendedor);

                    if (success)
                    {
                        MessageBox.Show("Usuário excluído com sucesso!");
                        LimparCampo();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível excluir o usuário. Verifique os dados e tente novamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Informe o ID do usuário a ser excluído.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao excluir o usuário: {ex.Message}");
            }
        }

        private void LimparCampo()
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
