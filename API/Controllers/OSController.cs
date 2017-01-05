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
    [RoutePrefix("api/os")]
    public class OSController : ApiController
    {
        private OsDAO osDao;
        private Servico servico;

        public OSController()
        {
            this.osDao = new OsDAO(new Conexao());
            this.servico = new Servico();
        }
        [AcceptVerbs("POST")]
        [Route("CadastrarOs")]
        public string CadastrarOS(OS os)
        {
            // ID da OS que vai ser gerado ao inserir no BD
            int idOs = 0;

            idOs = osDao.Insert(os);

            //Retorna o ID atualizado da OS
           // return idOs;
            return "Serviço cadastrado com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarPorCodigo/{idOs}")]
        public  List <Servico> ConsultarOsPorCodigo(int idOs)
        {
           return osDao.GetListaOs(idOs);
        }
    }
}
