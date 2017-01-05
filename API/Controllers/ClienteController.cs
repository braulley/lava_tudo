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
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        private ClienteDAO clienteDao;
        
        public ClienteController()
        {
            this.clienteDao = new ClienteDAO(new Conexao());
        }
        [AcceptVerbs("POST")]
        [Route("CadastrarCliente")]
        public string CadastrarCliente(Cliente cliente)
        {
            clienteDao.Insert(cliente);
                  
            return "Usuário cadastrado com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarOsPorCliente/{idCliente}")]
        public List <OS> ConsultarOsPorCliente(int idCliente)
        {
            return clienteDao.GetListaOsPorCliente(idCliente);
        }
    }
}
