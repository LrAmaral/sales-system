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
    public partial class ListarVendas : Form
    {
        public ListarVendas()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vendaDal dal = new vendaDal();
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListarVendas_Load(object sender, EventArgs e)
        {
            vendaDal dal = new vendaDal();
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }
    }
}
