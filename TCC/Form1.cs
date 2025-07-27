using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using static TCC.conexaoBD;

namespace TCC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Painel central do formulário
        private void panelCentral_Paint(object sender, PaintEventArgs e)
        {
        }


        //Validação de senha com pelo menos 8 caracteres, 1 letra maiúscula, 1 minúscula, 1 número e 1 símbolo especial
        public static bool ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                return false;

            string padrao = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
            return Regex.IsMatch(senha, padrao);
        }

        // Envia um e-mail de confirmação após o cadastro
        public void EnviarEmail(string destinatario, string nomeUsuario)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("daitogio@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Cadastro realizado com sucesso!";
                mail.Body = $"Olá {nomeUsuario},\n\nSeu cadastro foi concluído com sucesso!\n\nAbraços,\nEquipe do Sistema\nResponda o nosso questionário e dê seu feedback: https://forms.gle/bpbNwBsx4JvToDLZ8";
                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("daitogito@gmail.com", "yayl grdo dwtq mqgc"); // senha de app do Gmail
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("E-mail enviado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar e-mail: " + ex.Message);
            }
        }

        // Valida o CPF, removendo caracteres não numéricos e verificando o formato
        public static bool ValidarCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int digito1 = soma % 11;
            digito1 = (digito1 < 2) ? 0 : 11 - digito1;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            int digito2 = soma % 11;
            digito2 = (digito2 < 2) ? 0 : 11 - digito2;

            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }

        // Valida o formato do e-mail usando uma expressão regular simples
        public static bool ValidarEmail(string email)
        {
            string padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padrao, RegexOptions.IgnoreCase);
        }

        // Evento do botão de cadastro
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string senha = txtSenha.Text;

            if (!ValidarSenha(senha))//Validando a senha
            {
                MessageBox.Show("Senha inválida! A senha deve ter no mínimo 8 caracteres, com letras maiúsculas, minúsculas, números e símbolos.",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return;
            }

            // Coleta os dados do formulário
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string cpf = txtCPF.Text;
            string dataNascimento = txtAniversario.Text;

            if (!ValidarCPF(cpf))// Validando o CPF 
            {
                MessageBox.Show("CPF inválido! Por favor, verifique.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPF.Focus();
                return;
            }

            if (!ValidarEmail(email))// Validando o e-mail
            {
                MessageBox.Show("E-mail inválido! Verifique o endereço digitado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = ConexaoBD.ObterConexao())// Conexão com o banco de dados
                {
                    conn.Open();

                    string sql = "INSERT INTO usuario (nome_completo, senha, cpf, data_nascimento, email) " +
                                 "VALUES (@nome, @senha, @cpf, @data, @email)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@senha", senha);
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        cmd.Parameters.AddWithValue("@data", dataNascimento);
                        cmd.Parameters.AddWithValue("@email", email);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuário cadastrado com sucesso no banco de dados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EnviarEmail(email, nome); // Só envia se cadastrou com sucesso
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide(); // Esconde o formulário atual
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Abre o Form2
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show(); 
            this.Hide(); 
        }
    }
}
