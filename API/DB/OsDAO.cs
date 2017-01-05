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
    public class OsDAO
    {
        private Conexao conexaoBD;

        //Construtor recebe a conexão do banco de dados
        public OsDAO(Conexao conexaoBD)
        {
            this.conexaoBD = conexaoBD;
        }

        public int Insert(OS os)
        {

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                 //Monta a query
                comando.CommandText = "INSERT INTO os(IDCliente,datacontratacao,dataexecucao) " +
                            "VALUES(@IDCliente, @datacontratacao, @dataexecucao ); SELECT last_insert_id()";

                //Substitui os parâmetros da query, com cada atributo utilizado             
                comando.Parameters.Add("@IDCliente", MySqlDbType.Int16).Value = os.cliente.Codigo;
                comando.Parameters.Add("@datacontratacao", MySqlDbType.Date).Value = os.dataContratacao;
                comando.Parameters.Add("@dataexecucao", MySqlDbType.Date).Value = os.dataExecucao;

                //Resgata o ID gerado pelo banco de dados (comando last_insert_id() usado na query)
                os.Codigo = int.Parse(comando.ExecuteScalar().ToString());

            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //Retorna o ID atualizado do cliente
            return os.Codigo;
        }

        public List<Servico> GetListaOs(int idOs)
        {
            Servico servico = null;
            List<Servico> listservice = new List<Servico>();
            //Objeto Mysql que é retornado na consulta
            MySqlDataReader reader;

            //Cria um objeto 'comando' para manipular a query e a execução
            using (MySqlCommand comando = conexaoBD.buscar().CreateCommand()) //conexaoBD.buscar() inicia a conexão ao banco de dados
            {
                //Parâmetro Type do comando
                comando.CommandType = CommandType.Text;
                //Monta a query

                comando.CommandText = "SELECT s.ID, s.nome, s.valorfinal, s.custoempresa, s.IDEndereco, s.IDOs, o.datacontratacao, o.dataexecucao, o.IDCliente, c.nome, c.email, c.datanasc, c.residencial, c.celular, e.ID" +
                                      "FROM servico s, os o, cliente c " +
                                      "WHERE s.IDOs = @ID and s.IDEndereco= e.ID and o.IDCliente = c.ID  ";

                //Substitui os parâmetros da query, com cada atributo utilizado
                comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = idOs;

                //Executa o comando para resgatar os dados no objeto 'reader'
                reader = comando.ExecuteReader();

                //Para cada registro encontrado
                while (reader.Read())
                {
                    //Cria um objeto zerado
                    servico = new Servico();
                    //Seta os dados resgatados no objeto criado
                    servico.Codigo = int.Parse(reader["ID"].ToString());
                    servico.nomeservico = reader["nome"].ToString();
                    servico.valorfinal = double.Parse(reader["valorfinal"].ToString());
                    servico.custoEmpresa = double.Parse(reader["custoempresa"].ToString());
                    servico.endereco.Codigo = int.Parse(reader["IDEndereco"].ToString());
                    servico.endereco.logradouro = reader["logradouro"].ToString();
                    servico.endereco.numero = int.Parse(reader["numero"].ToString());
                    servico.endereco.complemento = reader["complemento"].ToString();
                    servico.endereco.bairro = reader["bairro"].ToString();
                    servico.endereco.cidade = reader["cidade"].ToString();
                    servico.endereco.uf = reader["uf"].ToString();
                    servico.endereco.cep = reader["cep"].ToString();
                    servico.os.Codigo = int.Parse(reader["IDOs"].ToString());
                    servico.os.dataContratacao = DateTime.Parse(reader["datacontratacao"].ToString());
                    servico.os.dataExecucao = DateTime.Parse(reader["dataexecucao"].ToString());
                    servico.os.cliente.Codigo = int.Parse(reader["IDCliente"].ToString());
                    servico.os.cliente.nome = reader["nome"].ToString();
                    servico.os.cliente.email = reader["email"].ToString();
                    servico.os.cliente.DataNasc = DateTime.Parse(reader["datanasc"].ToString());
                    servico.os.cliente.residencial = reader["residencial"].ToString();
                    servico.os.cliente.celular = reader["celular"].ToString();
                    listservice.Add(servico);                    
                }
                //Fecha o leitor
                reader.Close();
            }

            //Encerra a conexão no banco de dados
            conexaoBD.fechar();

            //retorna a lista de Servicos preenchidas
            return listservice;
        }
    }
}