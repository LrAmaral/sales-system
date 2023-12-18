using SistemaVenda.Classes;
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

namespace SistemaVenda.View.Painel
{
    public partial class Cadastro : Form
    {
        private userDal _userDal;

        public Cadastro()
        {
            InitializeComponent();
            _userDal = new userDal();
            CenterToScreen();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
                
            if (textBox1.Text.Length > 0 && tbNome.Text.Length > 0 && tbSenha.Text.Length > 0)
            {
                string nome = tbNome.Text;
                string senha = tbSenha.Text;
                string papel = textBox1.Text;

                user newUser = new user()
                {
                    nome = nome,
                    senha = senha,
                    papel = papel
                };
                
                bool sucesso = _userDal.Insert(newUser);

                if (sucesso)
                {
                    MessageBox.Show("Inserção bem-sucedida!");
                    LimparCampos();
                }
            }
            else
            {
                MessageBox.Show("Não é possível realizar o cadastro sem informações!",
                    "Alerta crítico",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
            }
        }

        private void LimparCampos()
        {
            textBox1.Clear();
            tbNome.Clear();
            tbSenha.Clear();
        }

        private void tbNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
