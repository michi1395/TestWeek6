using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6
{
    class Menù
    {
        static public void Start()
        {
            Console.WriteLine("-------Benvenuto nella Tua BANCA!-------");
            int scelta = 0;
            do
            {

                Console.WriteLine("\nPremi");
                Console.WriteLine();
                Console.WriteLine("[1]  Creare il tuo conto");
                Console.WriteLine("[2]  Aggiungere un nuovo Movimento");
                Console.WriteLine("[3]  Stampare i dati conto e i movimenti");
                Console.WriteLine("[0]  Uscire");



                bool isInt = true;

                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out scelta);
                    if (!isInt)
                    {
                        Console.WriteLine("La scelta è sbagliata... Riprova");
                    }
                } while (!isInt);
                switch (scelta)
                {
                    case 1:
                        Console.Clear();
                        BancaManager.AggiungiConto();

                        break;
                    case 2:
                        Console.Clear();
                        BancaManager.AggiungiMovimento();
                        
                        break;
                    case 3:
                        Console.Clear();
                        BancaManager.Stampa();
                        
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine(new String('=', 100));
                        Console.WriteLine("");
                        Console.WriteLine("Grazie per aver usufruito dei nostri servizi!!!");
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata... Riprova");
                        break;

                }
            } while (scelta != 0);
        }
    }
}
