using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generatore_di_Bolla
{

    public class Materiale : IGeneraCodice
    {
        string _nome { get; set; } = "";
        LineaProduzione _lineaDiProduzione { get; set; }
        string _codice { get; set; } = "";
        byte _revisione { get; set; } = 0;

        public string Codice => _codice;

        public Materiale(string nome, LineaProduzione lp, byte revisione)
        {
            this._nome = nome;
            this._lineaDiProduzione = lp;
            this._codice = SetId(lp);
            this._revisione = revisione;
        }

        public string SetId(LineaProduzione lp)
        {
            Random random = new Random();
            string validChar = "12345678";
            string generateCod = "";

            for (int i = 0; i <= 5; i++)
            {
                generateCod += validChar[random.Next(0, validChar.Length)];
            }

            return _codice += lp.ToString() + generateCod;
        }

        public override string ToString()
        {
            return $"[Descrzione Materiale]\n" +
                   $"Nome:\t\t\t{_nome}\n" +                  
                   $"Linea di produzione:\t{_lineaDiProduzione}\n" +
                   $"Codice:\t\t\t{_codice}\n" +
                   $"Revisione\t\t{_revisione}";
        }
    }
}
