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

        private bool NomeApenasLetras(string nome)
        {
            return Regex.IsMatch(nome, @"^[a-zA-Z\s]+$");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text) && textBox2.Text.Length > 0 && textBox4.Text.Length > 0)
                {
                    c.nome = textBox1.Text;

                    if (!NomeApenasLetras(textBox1.Text))
                    {
                        MessageBox.Show("O nome do cliente deve conter apenas letras.",
                            "Alerta crítico",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    string cpfInput = textBox2.Text;

                    string onlyNumbers = Regex.Replace(cpfInput, @"[^\d]", "");

                    if (onlyNumbers.Length == 11 && long.TryParse(onlyNumbers, out long cpf) && cpf != 0)
                    {
                        c.cpf = cpf;
                    }
                    else
                    {
                        MessageBox.Show("CPF inválido. Certifique-se de inserir um valor numérico válido para o CPF com exatamente 11 dígitos.",
                            "Alerta crítico",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (int.TryParse(textBox4.Text, out int idade))
                    {
                        if (idade < 0)
                        {
                            MessageBox.Show("A idade não pode ser um número negativo.",
                                "Alerta crítico",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        if (textBox4.Text.Length != 2)
                        {
                            MessageBox.Show("A idade é inválida.",
                                "Alerta crítico",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        if (idade < 18)
                        {
                            MessageBox.Show("O cliente não pode ter menos de 18 anos.",
                                "Alerta crítico",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        c.idade = idade;
                    }
                    else
                    {
                        MessageBox.Show("Idade inválida. Certifique-se de inserir um valor numérico válido para a idade.",
                            "Alerta crítico",
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
                        MessageBox.Show("Não foi possível realizar o cadastro!",
                            "Alerta crítico!",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
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