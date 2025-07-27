namespace TCC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelCentral = new Panel();
            txtCPF = new MaskedTextBox();
            lblCPF = new Label();
            lblAniversário = new Label();
            lblSenha = new Label();
            lblEmail = new Label();
            lblNome = new Label();
            btnCadastrar = new Button();
            txtAniversario = new TextBox();
            txtSenha = new TextBox();
            txtEmail = new TextBox();
            txtNome = new TextBox();
            label2 = new Label();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            panelCentral.SuspendLayout();
            SuspendLayout();
            // 
            // panelCentral
            // 
            panelCentral.AutoSize = true;
            panelCentral.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelCentral.BackColor = Color.PaleTurquoise;
            panelCentral.BorderStyle = BorderStyle.FixedSingle;
            panelCentral.Controls.Add(linkLabel1);
            panelCentral.Controls.Add(txtCPF);
            panelCentral.Controls.Add(lblCPF);
            panelCentral.Controls.Add(lblAniversário);
            panelCentral.Controls.Add(lblSenha);
            panelCentral.Controls.Add(lblEmail);
            panelCentral.Controls.Add(lblNome);
            panelCentral.Controls.Add(btnCadastrar);
            panelCentral.Controls.Add(txtAniversario);
            panelCentral.Controls.Add(txtSenha);
            panelCentral.Controls.Add(txtEmail);
            panelCentral.Controls.Add(txtNome);
            panelCentral.Controls.Add(label2);
            panelCentral.Controls.Add(label1);
            panelCentral.Dock = DockStyle.Fill;
            panelCentral.Location = new Point(0, 0);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(800, 420);
            panelCentral.TabIndex = 2;
            panelCentral.Paint += panelCentral_Paint;
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(256, 314);
            txtCPF.Mask = "000.000.000-00";
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(87, 22);
            txtCPF.TabIndex = 24;
            // 
            // lblCPF
            // 
            lblCPF.AutoSize = true;
            lblCPF.Location = new Point(214, 315);
            lblCPF.Name = "lblCPF";
            lblCPF.Size = new Size(28, 14);
            lblCPF.TabIndex = 23;
            lblCPF.Text = "CPF";
            // 
            // lblAniversário
            // 
            lblAniversário.AutoSize = true;
            lblAniversário.Location = new Point(177, 269);
            lblAniversário.Name = "lblAniversário";
            lblAniversário.Size = new Size(69, 14);
            lblAniversário.TabIndex = 21;
            lblAniversário.Text = "Aniversário";
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(209, 220);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(40, 14);
            lblSenha.TabIndex = 20;
            lblSenha.Text = "Senha";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(211, 169);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 14);
            lblEmail.TabIndex = 19;
            lblEmail.Text = "Email";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(210, 123);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(38, 14);
            lblNome.TabIndex = 18;
            lblNome.Text = "Nome";
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(359, 340);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(91, 27);
            btnCadastrar.TabIndex = 17;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // txtAniversario
            // 
            txtAniversario.Location = new Point(255, 265);
            txtAniversario.Name = "txtAniversario";
            txtAniversario.Size = new Size(317, 22);
            txtAniversario.TabIndex = 16;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(255, 216);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(317, 22);
            txtSenha.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(255, 165);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(317, 22);
            txtEmail.TabIndex = 14;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(255, 119);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(317, 22);
            txtNome.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(279, 64);
            label2.Name = "label2";
            label2.Size = new Size(238, 28);
            label2.TabIndex = 12;
            label2.Text = "Está pronto para essa Melhoria no Ensino? \r\nSiga nossas redes para mais informações";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(321, 22);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 11;
            label1.Text = "Crie sua Conta";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(321, 370);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(168, 14);
            linkLabel1.TabIndex = 25;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Já possui um cadastro?-Login";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(panelCentral);
            Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro";
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelCentral;
        private Label lblAniversário;
        private Label lblSenha;
        private Label lblEmail;
        private Label lblNome;
        private Button btnCadastrar;
        private TextBox txtAniversario;
        private TextBox txtSenha;
        private TextBox txtEmail;
        private TextBox txtNome;
        private Label label2;
        private Label label1;
        private Label lblCPF;
        private MaskedTextBox txtCPF;
        private LinkLabel linkLabel1;
    }
}
