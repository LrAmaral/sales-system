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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaVenda
{
    public partial class DeletarCliente : Form
    {
        public DeletarCliente()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBox1.Text, out int codCliente) && codCliente > 0)
                {
                    clienteDal dal = new clienteDal();

                    bool hasVendas = dal.ClientesNaVenda(codCliente);

                    if (hasVendas)
                    {
                        MessageBox.Show("Não é possível excluir o cliente porque existem vendas associadas a ele.");
                    }
                    else
                    {
                        bool success = dal.Delete(codCliente);

                        if (success)
                        {
                            MessageBox.Show("Cliente excluído com sucesso!");
                            LimparCampo();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível excluir o cliente. Verifique os dados e tente novamente.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Informe um ID de cliente válido (números inteiros positivos).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao excluir o cliente: {ex.Message}");
            }
        }

        private void LimparCampo()
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeletarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
