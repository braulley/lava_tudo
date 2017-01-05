using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace API.DB
{
    public class EnderecoDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public EnderecoDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        public int Insert(Endereco endereco)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {

                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO endereco(logradouro, numero, complemento, bairro, cidade, uf, cep)" +
                            " VALUES(@logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep); SELECT last_insert_id()";
                
                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@logradouro", MySqlDbType.Text).Value = endereco.logradouro;
                comando.Parameters.Add("@numero", MySqlDbType.Int16).Value = endereco.numero;
                comando.Parameters.Add("@complemento", MySqlDbType.Text).Value = endereco.complemento;
                comando.Parameters.Add("@bairro", MySqlDbType.Text).Value = endereco.bairro;
                comando.Parameters.Add("@cidade", MySqlDbType.Text).Value = endereco.cidade;
                comando.Parameters.Add("@uf", MySqlDbType.Text).Value = endereco.uf;
                comando.Parameters.Add("@cep", MySqlDbType.Text).Value = endereco.cep;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                endereco.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return endereco.Codigo;
        }

    }
}