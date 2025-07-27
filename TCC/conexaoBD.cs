using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC
{
    internal class conexaoBD
    {
        public static class ConexaoBD
        {
            public static MySqlConnection ObterConexao()
            {
                string conexao = "Server=localhost;User=root;Pwd=daitogito651;Database=school";
                return new MySqlConnection(conexao);
            }
        }
    }
}
