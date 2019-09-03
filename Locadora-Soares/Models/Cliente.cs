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
    }
}