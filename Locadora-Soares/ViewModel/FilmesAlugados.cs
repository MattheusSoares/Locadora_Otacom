using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora_Soares.ViewModel
{
    public class FilmesAlugados
    {
        public int ID_Cliente { get; set; }

        public String Cliente { get; set; }

        public int ID_Filme { get; set; }

        public String Filme { get; set; }

        [DisplayFormat(DataFormatString = "{0:F}")]
        public DateTime Horario { get; set; }

        public FilmesAlugados() { }

        public FilmesAlugados(String cliente, String filme, DateTime horario)
        {
            this.Cliente = cliente;
            this.Filme = filme;
            this.Horario = horario;
        }
        public FilmesAlugados(int id_cliente, String cliente, int id_filme, String filme, DateTime horario)
        {
            this.ID_Cliente = id_cliente;
            this.Cliente = cliente;
            this.ID_Filme = id_filme;
            this.Filme = filme;
            this.Horario = horario;
        }
    }
}