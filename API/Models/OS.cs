using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class OS
    {
        public int Codigo { get; set; }
        public Cliente cliente { get; set; }
        public DateTime dataContratacao { get; set; }
        public DateTime dataExecucao { get; set; }

        public static int ultimoCod;

        static OS()
        {
            ultimoCod = 1;
        }

        public OS()
        {
            Init(0, new Cliente(), new DateTime(), new DateTime());
        }

        public OS(int Codigo, Cliente cliente, DateTime dataContratacao, DateTime datExecucao)
        {
            Init(Codigo, cliente, dataContratacao, dataExecucao);
        }

        /*public Servico(int Codigo, string nomeservico, double valorfinal, double custoEmpresa, DateTime dataexecucao
            , DateTime datacontratacao, Endereco endereco)
        {
            Init(0, nomeservico, valorfinal, custoEmpresa, dataexecucao, datacontratacao, endereco);
        }*/

        private void Init(int Codigo, Cliente cliente, DateTime dataContratacao, DateTime datExecucao)
        {
            if (Codigo == 0)
                this.Codigo = ultimoCod++;
            this.cliente = cliente;
            this.dataContratacao = dataContratacao;
            this.dataExecucao = dataExecucao;


        }

    }
}