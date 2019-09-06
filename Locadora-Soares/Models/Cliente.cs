using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora_Soares.Models
{
    public class Cliente
    {
        public int ID{ get; set; }

        public String Nome{ get; set; }

        public String Login { get; set; }

        public String Senha{ get; set; }

        public Cliente() { }

        public Cliente(String nome, String login, String senha)
        {
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
        }

        public Cliente(int id, String nome, String login, String senha)
        {
            this.ID = id;
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
        }
    }
}