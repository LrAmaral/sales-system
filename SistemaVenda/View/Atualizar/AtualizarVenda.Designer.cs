namespace SistemaVenda.Forms
{
    partial class AtualizarVenda
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
            label5 = new Label();
            groupBox1 = new GroupBox();
            button3 = new Button();
            label4 = new Label();
            textBox4 = new TextBox();
            button2 = new Button();
            label6 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(714, 405);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 6;
            label5.Text = "Cancelar";
            label5.Click += label5_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(button1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 427);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Atualizar Venda";
            // 
            // button3
            // 
            button3.BackColor = Color.Olive;
            button3.ForeColor = Color.Cornsilk;
            button3.Location = new Point(266, 329);
            button3.Name = "button3";
            button3.Size = new Size(118, 32);
            button3.TabIndex = 18;
            button3.Text = "Buscar ";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 121);
            label4.Name = "label4";
            label4.Size = new Size(230, 21);
            label4.TabIndex = 17;
            label4.Text = "Altere a Quantidade do Produto";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 145);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(254, 29);
            textBox4.TabIndex = 16;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 192, 0);
            button2.ForeColor = Color.Cornsilk;
            button2.Location = new Point(390, 329);
            button2.Name = "button2";
            button2.Size = new Size(181, 33);
            button2.TabIndex = 12;
            button2.Text = "Atualizar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 46);
            label6.Name = "label6";
            label6.Size = new Size(149, 21);
            label6.TabIndex = 11;
            label6.Text = "Digite o Id da Venda";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(163, 29);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(266, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(504, 295);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(658, 391);
            button1.Name = "button1";
            button1.Size = new Size(112, 27);
            button1.TabIndex = 7;
            button1.Text = "Voltar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AtualizarVenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AtualizarVenda";
            Text = "AtualizarVenda";
            Load += AtualizarVenda_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private GroupBox groupBox1;
        private Button button3;
        private Label label4;
        private TextBox textBox4;
        private Button button2;
        private Label label6;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button button1;
    }
}