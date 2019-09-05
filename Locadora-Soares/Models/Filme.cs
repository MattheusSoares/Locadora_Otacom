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

        public int Disponivel { get; set; }

        public Filme() { }
        public Filme(String nome, int ano, String categoria) {
            this.Nome = nome;
            this.Ano = ano;
            this.Categoria = categoria;
        }

        public Filme(int id, String nome, int ano, String categoria) {
            this.ID = id;
            this.Nome = nome;
            this.Ano = ano;
            this.Categoria = categoria;
        }

        public Filme(int id, String nome, int ano, String categoria, int disponivel) {
            this.ID = id;
            this.Nome = nome;
            this.Ano = ano;
            this.Categoria = categoria;
            this.Disponivel = disponivel;
        }
    }
}