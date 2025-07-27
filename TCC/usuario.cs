using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TCC
{
    internal class usuario
    {
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public usuario() { }

        //Classe usuario
        public usuario(int idUsuario, string nomeCompleto, string senha, string cpf, string dataNascimento, string emaill)
        {
            IdUsuario = idUsuario;
            NomeCompleto = nomeCompleto;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Email = emaill;
            Senha = Senha;
        }

    }
}
