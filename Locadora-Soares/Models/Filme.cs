using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora_Soares.Models
{
    public class Filme
    {
        public int ID{ get; set; }

        public String Nome { get; set; }
        
        public int Ano{ get; set; }

        public String Categoria{ get; set; }

        public int? ID_Cliente{ get; set; }
    }
}