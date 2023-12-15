using Azure;
using SistemaVenda.Dal;
using SistemaVenda.Forms;
using SistemaVenda.View.Painel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaVenda.FormCliente;


namespace SistemaVenda
{
    public partial class MenuLogin : Form
    {
        public MenuLogin()
        {
            InitializeComponent();
            CenterToScreen();
        }

        static string _connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;



        private string VerificarCredenciais(string nomeUsuario, string senhaUsuario)
        {
            userDal userDal = new userDal();
            DataTable userTable = userDal.FindByNomeAndSenha(nomeUsuario, senhaUsuario);

            if (userTable.Rows.Count > 0)
            {
                string papel = userTable.Rows[0]["papel"].ToString();
                return papel;
            }

            return "";
        }


        private void MenuLogincs_Load(object sender, EventArgs e)
        {
        }

        private void lbCadastrar_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();

            cadastro.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
                {
                    string usuario = textBox1.Text;
                    string senha = textBox2.Text;

                    string papel = VerificarCredenciais(usuario, senha);

                    if (!string.IsNullOrEmpty(papel))
                    {
                        MessageBox.Show("Login bem-sucedido!", "Login");


                        if (papel.ToLower() == "vendedor")
                        {
                            PainelPrincipalVendedor formVendedor = new PainelPrincipalVendedor();
                            formVendedor.Show();
                        }
                        else if (papel.ToLower() == "gerente")
                        {
                            PainelPrincipalGerente formGerente = new PainelPrincipalGerente();
                            formGerente.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credenciais inválidas!",
                            "Alerta crítico!",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Todos os campos precisam ser preenchidos!",
                        "Alerta crítico!",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
