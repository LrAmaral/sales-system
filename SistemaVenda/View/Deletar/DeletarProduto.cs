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
    public partial class DeletarProduto : Form
    {
        public DeletarProduto()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    int codProduto = int.Parse(textBox1.Text);

                    produtoDal dal = new produtoDal();

                    bool hasVendas = dal.ProdutoNaVenda(codProduto);

                    if (hasVendas)
                    {
                        MessageBox.Show("Não é possível excluir o produto porque existem vendas associadas a ele.");
                    }
                    else
                    {
                        bool success = dal.Delete(codProduto);

                        if (success)
                        {
                            MessageBox.Show("Produto excluído com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível excluir o produto. Verifique os dados e tente novamente.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Informe o ID do produto a ser excluído.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao excluir o produto: {ex.Message}");
            }
        }
    }
}
