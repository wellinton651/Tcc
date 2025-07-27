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

        //Painel central do formul�rio
        private void panelCentral_Paint(object sender, PaintEventArgs e)
        {
        }


        //Valida��o de senha com pelo menos 8 caracteres, 1 letra mai�scula, 1 min�scula, 1 n�mero e 1 s�mbolo especial
        public static bool ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                return false;

            string padrao = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
            return Regex.IsMatch(senha, padrao);
        }

        // Envia um e-mail de confirma��o ap�s o cadastro
        public void EnviarEmail(string destinatario, string nomeUsuario)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("daitogio@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Cadastro realizado com sucesso!";
                mail.Body = $"Ol� {nomeUsuario},\n\nSeu cadastro foi conclu�do com sucesso!\n\nAbra�os,\nEquipe do Sistema\nResponda o nosso question�rio e d� seu feedback: https://forms.gle/bpbNwBsx4JvToDLZ8";
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

        // Valida o CPF, removendo caracteres n�o num�ricos e verificando o formato
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

        // Valida o formato do e-mail usando uma express�o regular simples
        public static bool ValidarEmail(string email)
        {
            string padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padrao, RegexOptions.IgnoreCase);
        }

        // Evento do bot�o de cadastro
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string senha = txtSenha.Text;

            if (!ValidarSenha(senha))//Validando a senha
            {
                MessageBox.Show("Senha inv�lida! A senha deve ter no m�nimo 8 caracteres, com letras mai�sculas, min�sculas, n�meros e s�mbolos.",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return;
            }

            // Coleta os dados do formul�rio
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string cpf = txtCPF.Text;
            string dataNascimento = txtAniversario.Text;

            if (!ValidarCPF(cpf))// Validando o CPF 
            {
                MessageBox.Show("CPF inv�lido! Por favor, verifique.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPF.Focus();
                return;
            }

            if (!ValidarEmail(email))// Validando o e-mail
            {
                MessageBox.Show("E-mail inv�lido! Verifique o endere�o digitado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = ConexaoBD.ObterConexao())// Conex�o com o banco de dados
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

                    MessageBox.Show("Usu�rio cadastrado com sucesso no banco de dados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EnviarEmail(email, nome); // S� envia se cadastrou com sucesso
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide(); // Esconde o formul�rio atual
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usu�rio: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
