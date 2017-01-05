using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.DB;
using API.Models;

namespace API.Controllers
{
    [RoutePrefix("api/servico")]
    public class ServicoController : ApiController
    {
        private ServicoDAO servicoDao;
        private EnderecoDAO enderecoDao;
        private OsDAO OsDao;

        public ServicoController()
        {
            this.servicoDao = new ServicoDAO(new Conexao());
            this.enderecoDao = new EnderecoDAO(new Conexao());
            this.OsDao = new OsDAO(new Conexao());
        }

        [AcceptVerbs("POST")]
        [Route("CadastrarServico")]
        public string CadastrarServico(Servico servico)
        {
            //ID do endereço que vai ser gerado ao inserir o endereço no BD
            int idEndereco = 0;
            int idOs = 0;

            /* idEndereco = enderecoDAO.Insert(cliente.Endereco);
             cliente.Endereco.Codigo = idEndereco;
             idCliente = clienteDAO.Insert(cliente);*/
            idEndereco = enderecoDao.Insert(servico.endereco);
            idOs = OsDao.Insert(servico.os);
            servico.os.Codigo = idOs;
            servico.endereco.Codigo = idEndereco;
            //idEndereco = servicoDao.Insert(servico);


            servicoDao.Insert(servico);

            return "Serviço cadastrado com sucesso!";
        }
    }
}
