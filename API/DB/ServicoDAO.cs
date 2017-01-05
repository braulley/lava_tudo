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
    public class ServicoDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public ServicoDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        public int Insert(Servico servico)
        {
            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO servico(nomeservico,IDEndereco, IDOs) " +
                            "VALUES(@nomeservico, @IDEndereco, @IDOs); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@nomeservico", MySqlDbType.Text).Value = servico.nomeservico;
                comando.Parameters.Add("@IDEndereco", MySqlDbType.Int16).Value = servico.endereco.Codigo;
                comando.Parameters.Add("@IDOs", MySqlDbType.Int16).Value = servico.os.Codigo;       

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                servico.Codigo = int.Parse(comando.ExecuteScalar().ToString());
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return servico.Codigo;
        }
    }
}