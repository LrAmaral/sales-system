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
    public partial class ListarVendedor : Form
    {
        public ListarVendedor()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            userDal dal = new userDal();
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void ListarVendedor_Load(object sender, EventArgs e)
        {
            userDal dal = new userDal();
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
