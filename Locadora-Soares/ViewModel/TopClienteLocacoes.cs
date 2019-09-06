using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora_Soares.ViewModel
{
    public class TopClienteLocacoes
    {
        public String Cliente { get; set; }

        public int Locacoes { get; set; }

        public TopClienteLocacoes() { }

        public TopClienteLocacoes(string cliente, int locacoes)
        {
            this.Cliente = cliente;
            this.Locacoes = locacoes;
        }
    }
}