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
    public partial class GerenciarCliente : Form
    {
        public GerenciarCliente()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FormCliente cadastro = new FormCliente();
            cadastro.ExibirCentralizadoMenuCadastro();
        }

        private void GerenciarCliente_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Buscar busca = new Buscar();
            busca.ExibirCentralizadoMenuCadastro();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ListarClientes listar = new ListarClientes();
            listar.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DeletarCliente delete = new DeletarCliente();
            delete.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AtualizarCliente atualiza = new AtualizarCliente();
            atualiza.Show();
        }
    }
}
