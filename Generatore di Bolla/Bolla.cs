using Generatore_di_Bolla.Personale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generatore_di_Bolla
{
    public interface IGeneraCodice
    {
        public string SetId(LineaProduzione lp);
    }

    public enum LineaProduzione
    {
        X016,
        X005,
        X999
    }

    public class Bolla : IGeneraCodice
    {
        string _idBolla = "XPR-";
        Responsabile _responsabile { get; set; }
        Materiale _materiale { get; set; }
        DateTime _creazioneBolla { get; set; }
        TimeSpan _tempoStimato { get; set; }
        string _descrizioneBolla { get; set; } = "";
        int _numeroPezzi { get; set; } = 0;
        LineaProduzione _lineaProduzione { get; set; }
        Dictionary<int, int> _pezziPerLotto { get; set; }
        static long _numeroBolla { get; set; } = 0;

        public string IdBolla
        {
            get { return _idBolla; }
            set { _idBolla = value; }
        }

        public Bolla(Responsabile responsabile, Materiale materiale, double tempoStimato, string descrizioneBolla, int numeroPezzi, LineaProduzione lp, int[] lotto)
        {
            Console.WriteLine("");
            _responsabile = responsabile;
            IdBolla = SetId(lp);
            _materiale = materiale;
            _creazioneBolla = DateTime.Now;
            _tempoStimato = TimeSpan.FromMinutes(tempoStimato);
            _descrizioneBolla = descrizioneBolla;
            _numeroPezzi = numeroPezzi;
            _lineaProduzione = lp;
            _pezziPerLotto = AssegnaPezziALotti(lotto, numeroPezzi);
            _numeroBolla++;
        }

        /// <summary>
        /// Permette di generare un codice unico da assegnare ad una bolla
        /// </summary>
        /// <returns>Codice generato</returns>
        public string SetId(LineaProduzione lp)
        {
            Random random = new Random();
            string validChar = "ABCDEFGHI12345678";
            string generateCod = "";

            for (int i = 0; i <= 8; i++)
            {
                generateCod += validChar[random.Next(0, validChar.Length)];
            }

            return lp.ToString() + generateCod;
        }

        /// <summary>
        /// Permette di assegnare una quantità di pezzi per lotto.
        /// Controlla la quantità di lotti registrati nella bolla e per ogni lotto verà assegnato
        /// un quantitativo di n pezzi.
        /// Assegnerà automaticamente i pezzi rimaneti all'ultimo lotto.
        /// </summary>
        /// <param name="lotti"></param>
        /// <param name="numeroPezzi"></param>
        /// <returns>Dizionario con i valori assegnati per ogni key</returns>
        private Dictionary<int, int> AssegnaPezziALotti(int[] lotti, int numeroPezzi)
        {
            Dictionary<int, int> PezziPerLotto = new Dictionary<int, int>();
            int pezziAssegnati = 0;

            if (lotti.Length == 1)
            {
                PezziPerLotto.Add(lotti[0], numeroPezzi);
                return PezziPerLotto;
            }
            else
            {
                for (int i = 0; i < lotti.Length && pezziAssegnati < numeroPezzi; i++)
                {
                    if (i + 1 == lotti.Length)
                    {
                        PezziPerLotto.Add(lotti[i], numeroPezzi - pezziAssegnati);
                        Console.Write($"Pezzi inseriti automaticamente per il lotto {lotti[i]}: {numeroPezzi - pezziAssegnati}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write($"Inserisci il numero dei pezzi per il lotto {lotti[i]} (pezzi rimanenti: {numeroPezzi - pezziAssegnati}): ");
                        int numeroPezziperLotto;

                        while (!int.TryParse(Console.ReadLine(), out numeroPezziperLotto) || numeroPezziperLotto <= 0 || numeroPezziperLotto > numeroPezzi - pezziAssegnati)
                        {
                            Console.WriteLine("Inserisci un valore valido.");
                            Console.Write($"Inserisci il numero dei pezzi per il lotto {lotti[i]} (pezzi rimanenti: {numeroPezzi - pezziAssegnati}): ");
                        }
                        PezziPerLotto.Add(lotti[i], numeroPezziperLotto);
                        pezziAssegnati += numeroPezziperLotto;
                    }
                }
            }

            return PezziPerLotto;
        }

        /// <summary>
        /// Permette di mostrare la quantità di pezzi per lotto.
        /// </summary>
        public void DettagliLotti()
        {
            Console.WriteLine("[Dettagli Lotto]");
            foreach (var i in _pezziPerLotto)
            {
                Console.WriteLine($"Lotto:\t{i.Key}\tPezzi:\t{i.Value}");
            }
        }

        public override string ToString()
        {
            return $"[\nDettagli Bolla {_numeroBolla}]\n" +
                   $"Id:\t\t\t{IdBolla}\n" +
                   $"Linea Produzione:\t{_lineaProduzione}\n" +                  
                   $"Data Creazione Bolla:\t{_creazioneBolla}\n" +
                   $"Tempo Previsto:\t\t{_tempoStimato}\n" +
                   $"Numero Pezzi:\t\t{_numeroPezzi}\n" +
                   $"Descrizione:\t\t{_descrizioneBolla}\n" +
                   $"{_materiale}\n";
        }
    }
}
