namespace SistemaVenda.Forms
{
    partial class PainelPrincipalVendedor
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
            label2 = new Label();
            label6 = new Label();
            label4 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(838, 9);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 15;
            label2.Text = "Sair";
            label2.Click += label2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(296, 9);
            label6.Name = "label6";
            label6.Size = new Size(131, 21);
            label6.TabIndex = 14;
            label6.Text = "Gerenciar Vendas";
            label6.Click += label6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(153, 9);
            label4.Name = "label4";
            label4.Size = new Size(137, 21);
            label4.TabIndex = 12;
            label4.Text = "Gerenciar Produto";
            label4.Click += label4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 9);
            label1.Name = "label1";
            label1.Size = new Size(129, 21);
            label1.TabIndex = 11;
            label1.Text = "Gerenciar Cliente";
            label1.Click += label1_Click;
            // 
            // PainelPrincipalVendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label1);
            IsMdiContainer = true;
            Name = "PainelPrincipalVendedor";
            Text = "PainelPrincipalVendedor";
            FormClosed += PainelPrincipalVendedor_FormClosed;
            Load += PainelPrincipalVendedor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label6;
        private Label label4;
        private Label label1;
    }
}