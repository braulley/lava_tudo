using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Servico
    {
        public int Codigo { get; set; }
        public string nomeservico { get; set; }
        public double valorfinal { get; set; }
        public double custoEmpresa { get; set; }
        public Endereco endereco { get; set; }
        public OS os { get; set; }
        public static int ultimoCod ;

        static Servico()
        {
            ultimoCod = 1;
        }

        public Servico()
        {
            Init(0, "", 0.00, 0.00, new Endereco(), new OS());
        }

        public Servico(int Codigo, string nomeservico, double valorfinal, double custoEmpresa, Endereco endereco, OS os)
        {
            Init(Codigo, nomeservico, valorfinal, custoEmpresa, endereco, os);
        }

        /*public Servico(int Codigo, string nomeservico, double valorfinal, double custoEmpresa, DateTime dataexecucao
            , DateTime datacontratacao, Endereco endereco)
        {
            Init(0, nomeservico, valorfinal, custoEmpresa, dataexecucao, datacontratacao, endereco);
        }*/

        private void Init(int Codigo,string nomeservico,double valorfinal, double custoEmpresa, Endereco endereco, OS os)
        {
            if (Codigo == 0)
                this.Codigo = ultimoCod++;

            this.nomeservico = nomeservico;
            this.valorfinal = valorfinal;
            this.custoEmpresa = custoEmpresa;
            this.endereco = endereco;
            this.os = os;
        }

    }
}