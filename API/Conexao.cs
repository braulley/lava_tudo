using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace API
{
    public class Conexao
    {
        //Atributo responsável pela conexão
        private MySqlConnection conexaoBD;

        public Conexao()
        {
            //Seta todos os dados necessários (servidor, usuário, senha e banco de dados)
            this.conexaoBD = new MySqlConnection("server=localhost;database=lava_tudo;uid=root;pwd='1234'");
        }

        //Abre a conexão no banco de dados
        public MySqlConnection abrir()
        {
            if (conexaoBD.State == ConnectionState.Closed)
            {
                conexaoBD.Open();
            }

            Console.WriteLine(conexaoBD.State.ToString());

            return conexaoBD;
        }

        //Retorna a conexão já aberta (evita de abrir uma nova)
        public MySqlConnection buscar()
        {
            return this.abrir();
        }

        //Encerra a conexão no banco de dados
        public void fechar()
        {
            if (conexaoBD.State == ConnectionState.Open)
            {
                conexaoBD.Close();
            }
        }
    }
}