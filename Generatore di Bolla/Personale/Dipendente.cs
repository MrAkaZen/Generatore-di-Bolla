using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generatore_di_Bolla.Personale
{
    public enum Reparto
    {
        Taglio, CNC, Piegatura, Saldatura, Molatura, Magazzino
    }

    public class Dipendente
    {
        protected int _id { get; set; }
        protected string _nome { get; set; } = "";
        protected string _cognome { get; set; } = "";

        public Dipendente(int id, string nome, string cognome)
        {
            _id = id;
            _nome = nome;
            _cognome = cognome;
        } 
    }
}
