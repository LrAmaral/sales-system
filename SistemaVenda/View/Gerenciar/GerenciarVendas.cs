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
    public partial class GerenciarVendas : Form
    {
        public GerenciarVendas()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FormVenda venda = new FormVenda();
            venda.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DeletarVendas delete = new DeletarVendas();
            delete.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ListarVendas listar = new ListarVendas();
            listar.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AtualizarVenda atualiza = new AtualizarVenda();
            atualiza.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            VendaBusca venda = new VendaBusca();
            venda.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void GerenciarVendas_Load(object sender, EventArgs e)
        {

        }
    }
}
