using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora_Soares.Models
{
    public class Admin
    {
        public String Login { get; set; }
        public String Senha { get; set; }

        public Admin(String login, String senha){
            this.Login = login;
            this.Senha = senha;
        }
    }
}