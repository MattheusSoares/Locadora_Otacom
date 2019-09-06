using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora_Soares.ViewModel
{
    public class TopFilmeLocacoes
    {
        public String Filme { get; set; }

        public int Locacoes { get; set; }

        public TopFilmeLocacoes() { }

        public TopFilmeLocacoes(string filme, int locacoes) {
            this.Filme = filme;
            this.Locacoes = locacoes;
        }
    }
}