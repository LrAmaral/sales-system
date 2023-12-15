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
    public partial class PainelPrincipalVendedor : Form
    {
        public PainelPrincipalVendedor()
        {
            InitializeComponent();
            CenterToScreen();
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

        private void label1_Click(object sender, EventArgs e)
        {
            GerenciarCliente cliente = new GerenciarCliente();
            AbrirFormulario(cliente);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            GerenciarProduto produto = new GerenciarProduto();
            AbrirFormulario(produto);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            GerenciarVendas vendas = new GerenciarVendas();
            AbrirFormulario(vendas);
        }

        private void PainelPrincipalVendedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PainelPrincipalVendedor_Load(object sender, EventArgs e)
        {         
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
