using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Generatore_di_Bolla.Personale
{
   

    public class Responsabile : Dipendente
    {
        static readonly string _qualifica = "Responsabile";
        Reparto _reparto { get; set; }

        public Responsabile(int id, string cognome, string nome, Reparto reparto) : base(id, nome, cognome)
        {
            this._reparto = reparto;

        }

        public Bolla CreaBolla(Materiale materiale,double tempoStimato, string descrizione, int numeroPezzi, LineaProduzione lp, int[] lotto)
        {
            return new Bolla(this, materiale, tempoStimato,descrizione,numeroPezzi,lp,lotto);

        }

        public override string ToString()
        {
            return $"Dipendente {_nome.ToUpper()} {_cognome.ToUpper()}\n\n" +
                $"Qualifica:\t{_qualifica}\n" +
                $"Reparto:\t{_reparto}\n";
        }
    }
}
