using SistemaVenda.Classes;
using SistemaVenda.Dal;
using System.Data;
using System.Text.RegularExpressions;

namespace SistemaVenda
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
            CenterToScreen();
        }
        public void ExibirCentralizadoMenuCadastro()
        {
            MdiParent = this.ParentForm;
            StartPosition = FormStartPosition.CenterScreen;
            Show();
        }

        cliente c = new cliente();
        clienteDal dal = new clienteDal();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox4.Text.Length > 0)
                {
                    c.nome = textBox1.Text;

                    if (long.TryParse(textBox2.Text, out long cpf))
                    {
                        if (cpf.ToString().Length == 11)
                        {
                            c.cpf = cpf;
                        }
                        else
                        {
                            MessageBox.Show("CPF inv�lido. Certifique-se de inserir um valor num�rico v�lido para o CPF com exatamente 11 d�gitos.",
                                "Alerta cr�tico",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("CPF inv�lido. Certifique-se de inserir um valor num�rico v�lido para o CPF.",
                            "Alerta cr�tico",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (int.TryParse(textBox4.Text, out int idade))
                    {
                        if (idade < 0)
                        {
                            MessageBox.Show("A idade n�o pode ser um n�mero negativo.",
                                "Alerta cr�tico",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        c.idade = idade;
                    }
                    else
                    {
                        MessageBox.Show("Idade inv�lida. Certifique-se de inserir um valor num�rico v�lido para a idade.",
                            "Alerta cr�tico",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    bool success = dal.Insert(c);

                    if (success)
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("N�o foi poss�vel realizar o cadastro!",
                            "Alerta cr�tico!",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("N�o � poss�vel realizar o cadastro sem informa��es!",
                        "Alerta cr�tico",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.ToString()}");
            }
        }

        private void button2_Click(object sender, EventArgs e)

        {
            DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar?",
                                                  "Cancelar venda",
                                                  MessageBoxButtons.YesNo);

            if (retorno == DialogResult.No)
            {
                return;
            }

            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox4.Text.Length > 0)
            {
                DialogResult retorno = MessageBox.Show("Tem certeza que deseja cancelar?",
                                                   "Cancelar venda",
                                                   MessageBoxButtons.YesNo);

                if (retorno == DialogResult.No)
                {
                    return;
                }
            }

            this.Close();
        }
    }
}