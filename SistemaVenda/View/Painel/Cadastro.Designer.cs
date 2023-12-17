namespace SistemaVenda.View.Painel
{
    partial class Cadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCadastrar = new Button();
            label1 = new Label();
            label2 = new Label();
            tbNome = new TextBox();
            tbSenha = new TextBox();
            textBox1 = new TextBox();
            Papel = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.FromArgb(0, 192, 0);
            btnCadastrar.ForeColor = Color.Cornsilk;
            btnCadastrar.Location = new Point(247, 199);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(105, 38);
            btnCadastrar.TabIndex = 0;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 17);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 77);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Senha";
            // 
            // tbNome
            // 
            tbNome.Location = new Point(35, 35);
            tbNome.Name = "tbNome";
            tbNome.Size = new Size(317, 23);
            tbNome.TabIndex = 2;
            tbNome.TextChanged += tbNome_TextChanged;
            // 
            // tbSenha
            // 
            tbSenha.Location = new Point(35, 95);
            tbSenha.Name = "tbSenha";
            tbSenha.Size = new Size(317, 23);
            tbSenha.TabIndex = 2;
            tbSenha.UseSystemPasswordChar = true;
            tbSenha.TextChanged += tbSenha_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(35, 150);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(317, 23);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Papel
            // 
            Papel.AutoSize = true;
            Papel.Location = new Point(35, 132);
            Papel.Name = "Papel";
            Papel.Size = new Size(36, 15);
            Papel.TabIndex = 3;
            Papel.Text = "Papel";
            // 
            // button1
            // 
            button1.Location = new Point(35, 207);
            button1.Name = "button1";
            button1.Size = new Size(91, 23);
            button1.TabIndex = 5;
            button1.Text = "Voltar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 262);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(Papel);
            Controls.Add(tbSenha);
            Controls.Add(tbNome);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCadastrar);
            Name = "Cadastro";
            Text = "Cadastro";
            Load += Cadastro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCadastrar;
        private Label label1;
        private Label label2;
        private TextBox tbNome;
        private TextBox tbSenha;
        private TextBox textBox1;
        private Label Papel;
        private Button button1;
    }
}