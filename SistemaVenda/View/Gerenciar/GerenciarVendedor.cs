using SistemaVenda.Classes;
using SistemaVenda.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVenda.Forms
{
    public partial class GerenciarVendedor : Form
    {
        public GerenciarVendedor()
        {
            InitializeComponent();
            CenterToScreen();
        }

        static string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        user p = new user();
        userDal dal = new userDal();

        private void label1_Click(object sender, EventArgs e)
        {
            FormVendedor vendedor = new FormVendedor();
            vendedor.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DeletarVendedor delete = new DeletarVendedor();
            delete.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ListarVendedor vendedor = new ListarVendedor();
            vendedor.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AtualizarVendedor atualiza = new AtualizarVendedor();
            atualiza.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            VendedorBusca vendedor = new VendedorBusca();
            vendedor.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
