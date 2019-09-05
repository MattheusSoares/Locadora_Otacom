using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora_Soares.Models
{
    public class Aluga
    {
        public int ID_Cliente{ get; set; }

        public int ID_Filme { get; set; }

        public DateTime Horario { get; set; }

        public int Devolvido { get; set; }

        public String Opcional { get; set; }

        public Aluga() { }

        public Aluga(int id_cliente, int id_filme, DateTime horario)
        {
            this.ID_Cliente = id_cliente;
            this.ID_Filme = id_filme;
            this.Horario = horario;
        }
        public Aluga(int id_cliente, int id_filme)
        {
            this.ID_Cliente = id_cliente;
            this.ID_Filme = id_filme;
        }

        public Aluga(int id_cliente, int id_filme, DateTime horario, int devolvido)
        {
            this.ID_Cliente = id_cliente;
            this.ID_Filme = id_filme;
            this.Horario = horario;
            this.Devolvido = devolvido;
        }

    }
}