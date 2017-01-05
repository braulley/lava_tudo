using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime DataNasc { get; set; }
        public string celular { get; set; }
        public string residencial { get; set; }
        private static int ultimoCod;
        
        public Cliente()
        {
            Init(0, "", "", new DateTime(), "", "");
        }
        public Cliente(int Id, string nome, string email, DateTime Datanasc, string celular, string residencial)
        {
            Init(Id, nome, email, Datanasc, celular, residencial);
        }
        /*public Cliente(int Id, string nome, string email, DateTime Datanasc,string celular,string residencial)
        {
            Init(0, nome, email, Datanasc, celular, residencial);
        }*/

        public void Init(int Id, string nome, string email, DateTime Datanasc, string celular, string residencial)
        {
            if (ultimoCod == 0)
                this.Codigo = ultimoCod++;
            this.nome = nome;
            this.email = email;
            this.DataNasc = DataNasc;
            this.residencial = residencial;
            this.celular = celular;

        }
    }
}