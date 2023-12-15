using SistemaVenda.Forms;
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
    public partial class GerenciarProduto : Form
    {
        public GerenciarProduto()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void GerenciarProduto_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var menu = new PainelPrincipalGerente();

            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var produto = new FormProduto();
            produto.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ProdutoBusca busca = new ProdutoBusca();
            busca.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ListarProduto produto = new ListarProduto();
            produto.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DeletarProduto delete = new DeletarProduto();
            delete.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AtualizarProduto atualiza = new AtualizarProduto();
            atualiza.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
