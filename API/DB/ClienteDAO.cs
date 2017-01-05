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
    public class ClienteDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public ClienteDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        public int Insert(Cliente cliente)
        {

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query
                comando.CommandText = "INSERT INTO cliente(nome, email, datanasc, celular, residencial) " +
                            "VALUES(@nome, @email, @datanasc, @celular, @residencial); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@nome", MySqlDbType.Text).Value = cliente.nome;
                comando.Parameters.Add("@email", MySqlDbType.Text).Value = cliente.email;
                comando.Parameters.Add("@datanasc", MySqlDbType.Date).Value = cliente.DataNasc;
                comando.Parameters.Add("@celular", MySqlDbType.Text).Value = cliente.celular;
                comando.Parameters.Add("@residencial", MySqlDbType.Text).Value = cliente.residencial;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                cliente.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return cliente.Codigo;
        }

        public List<OS> GetListaOsPorCliente(int idCliente)
        {
            OS os= null;
            List<OS> listos = new List<OS>();
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query

                comando.CommandText = "SELECT o.ID, o.datacontratacao, o.dataexecucao, o.IDCliente, c.ID, c.nome, c.email " +
                                      "FROM os o, cliente c" +
                                      "WHERE o.IDCliente = c.ID and c.ID=1";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idCliente;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    os = new OS();
                    //Seta os dados resgatados no objeto criado
                    os.Codigo = int.Parse(reader["ID"].ToString());
                    os.dataContratacao = DateTime.Parse(reader["datacontratacao"].ToString());
                    os.dataExecucao = DateTime.Parse(reader["dataexecucao"].ToString());
                    os.cliente.Codigo = int.Parse(reader["IDCliente"].ToString());
                    os.cliente.nome = reader["nome"].ToString();
                    os.cliente.email = reader["email"].ToString();
                    
                    listos.Add(os);
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna a lista de Servicos preenchidas
            return listos;
        }
    }
}