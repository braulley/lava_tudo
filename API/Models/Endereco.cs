using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Endereco
    {
        public int Codigo { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        private static int ultimoCod;

        static Endereco()
        {
            ultimoCod = 1;
        }

        public Endereco()
        {
            Init(0, "", 0, "", "", "", "", "");
        }

        public Endereco(int codEndereco, string logradouro, int numero, string complemento, string bairro, string cidade,
            string UF, string CEP)
        {
            Init(codEndereco, logradouro, numero, complemento, bairro, cidade, UF, CEP);
        }

        public Endereco(string lougradouro, int numero, string complemento, string bairro, string cidade,
            string UF, string CEP)
        {
            Init(0, logradouro, numero, complemento, bairro, cidade, UF, CEP);
        }

        private void Init(int codEndereco, string logradouro, int numero, string complemento, string bairro, string cidade,
            string UF, string CEP)
        {
            if (codEndereco == 0)
                this.Codigo = ultimoCod++;

            this.logradouro = logradouro;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cidade = cidade;
            this.uf = UF;
            this.cep = CEP;
        }


    }
}