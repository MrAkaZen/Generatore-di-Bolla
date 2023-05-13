using Generatore_di_Bolla.Personale;
using System;

namespace Generatore_di_Bolla;

class Program
{
    static void Main(string[] args)
    {
        Materiale m1 = new Materiale("Carter Copricanale", LineaProduzione.X016, 0);
        Materiale m2 = new Materiale("Mini-carter Copricanale", LineaProduzione.X016, 0);

        Responsabile resp1 = new Responsabile(432135, "Rossi", "Mario", Reparto.Magazzino);
        Console.WriteLine(resp1);

        Bolla bolla1 = resp1.CreaBolla(m1, 25, "Prova", 25, LineaProduzione.X016, new int[] { 123, 255 });
        Console.WriteLine(bolla1);
        bolla1.DettagliLotti();


        Bolla bolla2 = resp1.CreaBolla(m2, 21, "Prova", 12, LineaProduzione.X999, new int[] { 255 });
        Console.WriteLine(bolla2);
        bolla2.DettagliLotti();

    }
}
