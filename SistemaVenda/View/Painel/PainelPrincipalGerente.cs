

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
    public partial class PainelPrincipalGerente : Form
    {
        public PainelPrincipalGerente()
        {
            InitializeComponent();
            CenterToScreen();

            //this.MdiChildActivate += PainelPrincipal_MdiChildActivate;
        }

        //private void PainelPrincipal_MdiChildActivate(object sender, EventArgs e)
        //{
        //    if (ActiveMdiChild != null)
        //    {
        //        ActiveMdiChild.StartPosition = FormStartPosition.CenterScreen;
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private Form formularioAberto = null;

        private void FecharFormularioAberto()
        {
            if (formularioAberto != null)
            {
                formularioAberto.Close();
                formularioAberto = null;
            }
        }

        private void AbrirFormulario(Form novoFormulario)
        {
            FecharFormularioAberto();

            novoFormulario.MdiParent = this;
            novoFormulario.StartPosition = FormStartPosition.CenterScreen;

            novoFormulario.Show();

            formularioAberto = novoFormulario;
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            GerenciarCliente cliente = new GerenciarCliente();
            AbrirFormulario(cliente);
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            GerenciarProduto produto = new GerenciarProduto();
            AbrirFormulario(produto);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            GerenciarVendedor vendedor = new GerenciarVendedor();
            AbrirFormulario(vendedor);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            GerenciarVendas vendas = new GerenciarVendas();
            AbrirFormulario(vendas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
