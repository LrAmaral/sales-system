
namespace SistemaVenda.Forms
{
    partial class PainelPrincipalGerente
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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(447, 9);
            label6.Name = "label6";
            label6.Size = new Size(131, 21);
            label6.TabIndex = 9;
            label6.Text = "Gerenciar Vendas";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(293, 9);
            label5.Name = "label5";
            label5.Size = new Size(148, 21);
            label5.TabIndex = 8;
            label5.Text = "Gerenciar Vendedor";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(150, 9);
            label4.Name = "label4";
            label4.Size = new Size(137, 21);
            label4.TabIndex = 7;
            label4.Text = "Gerenciar Produto";
            label4.Click += label4_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(15, 9);
            label1.Name = "label1";
            label1.Size = new Size(129, 21);
            label1.TabIndex = 6;
            label1.Text = "Gerenciar Cliente";
            label1.Click += label1_Click_2;
            // 
            // button1
            // 
            button1.Location = new Point(797, 7);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Sair";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PainelPrincipalGerente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(884, 561);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            IsMdiContainer = true;
            Name = "PainelPrincipalGerente";
            Text = "Painel Administrativo - CommerceMaster";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void splitContainer1_Panel1_Paint_1(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Button button1;
    }
}