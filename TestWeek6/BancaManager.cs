using System;
using System.Collections.Generic;
using System.Linq;
using TestWeek6.Entities;
using static TestWeek6.Entities.CreditCardMovement;

namespace TestWeek6
{
    class BancaManager
    {
        static List<ContoCorrente> conti = new List<ContoCorrente>();
        public static void AggiungiConto()
        {
            ContoCorrente conto = new ContoCorrente();
            Console.Write("Inserisci numero conto corrente: ");
            conto.NumeroConto = Check();
            Console.Write("Inserisci nome banca: ");
            conto.NomeBanca = Console.ReadLine();
            Console.Write("Inserisci il tuo saldo: ");
            conto.Saldo = CheckImporto();
            conti.Add(conto);

        }

        public static decimal CheckImporto()
        {
            decimal num = 0;
            while (!decimal.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Puoi inserire solo numeri! Riprova: ");
            }

            return num;
        }

        public static int Check()
        {
            int num = 0;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Puoi inserire solo numeri! Riprova: ");
            }

            return num;

        }

        public static void AggiungiMovimento()
        {
            Console.WriteLine("------Conti correnti presenti------");
            Console.WriteLine();
            Console.WriteLine("{0,20}{1,20}{2,20}{3,20}{4,30}", "# Conto", "Numero Conto", "Nome Banca", "Saldo", "Data Ultima Operazione");
            Console.WriteLine(new String('-', 100));
            int count = 1;
            foreach (ContoCorrente conto in conti)
            {
                Console.WriteLine($"{count,20}{conto.NumeroConto,20}{conto.NomeBanca,20}{conto.Saldo,20}{conto.DataUltimaOperazione,30}");
                count++;
            }

            Console.WriteLine(new String('-', 100));

            int numConto = 0;
            Console.Write("Inserisci il conto: ");
            bool isInt = false;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out numConto);
            } while (!isInt || numConto < 0 || numConto > conti.Count);

            ContoCorrente contoScelto = conti.ElementAt(numConto - 1);

            Console.WriteLine("------Scegli il tipo di movimento------");
            Console.WriteLine("[1] CashMovement \n[2] TransferMovement \n[3] CreditCardMovement");
            int sceltaMov = Check();
            switch (sceltaMov)
            {
                case 1:
                    CashMovement movimento = new();
                    movimento.IsPrelievo = PrelievoVersamento();
                    movimento.DataMovimento = DateTime.Now.Date;
                    Console.Write("Inserisci nome e cognome dell'esecutore: ");
                    movimento.Esecutore = Console.ReadLine();
                    try
                    {
                        Console.Write("Inserisci importo da versare/prelevare: ");
                        movimento.Importo = CheckImporto();
                        AggiornaConto(contoScelto, movimento.IsPrelievo, movimento.Importo);
                        
                    }
                    catch(SaldoException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    contoScelto.Movimenti.Add(movimento);

                    break;

                case 2:
                    TransferMovement movimento1 = new();
                    movimento1.IsPrelievo = PrelievoVersamento();
                    movimento1.DataMovimento = DateTime.Now.Date;
                    Console.Write("Inserisci Banca di Origine: ");
                    movimento1.BancaOrigine = Console.ReadLine();
                    Console.Write("Inserisci Banca di Destinazione: ");
                    movimento1.BancaDestinazione = Console.ReadLine();
                    try
                    {
                        Console.Write("Inserisci importo da versare/prelevare: ");
                        movimento1.Importo = CheckImporto();
                        AggiornaConto(contoScelto, movimento1.IsPrelievo, movimento1.Importo);
                        
                    }
                    catch (SaldoException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    contoScelto.Movimenti.Add(movimento1);
                    break;

                case 3:
                    CreditCardMovement movimento2 = new();
                    movimento2.IsPrelievo = PrelievoVersamento();
                    movimento2.DataMovimento = DateTime.Now.Date;
                    Console.WriteLine("---------Inserisci Tipo di Carta--------");
                    movimento2.Tipologia = TipoCarta();

                    try
                    {
                        Console.Write("Inserisci importo da versare/prelevare: ");
                        movimento2.Importo = CheckImporto();
                        AggiornaConto(contoScelto, movimento2.IsPrelievo, movimento2.Importo);
                        
                    }
                    catch (SaldoException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    contoScelto.Movimenti.Add(movimento2);
                    break;


                default:
                    Console.WriteLine("Scelta non consentita!!");
                    break;
            }
        }

        private static void AggiornaConto(ContoCorrente contoScelto, bool isPrelievo, decimal importo)
        {
            if (isPrelievo)
            { 
                if (contoScelto.Saldo < importo)
                {
                    throw new SaldoException("------Non puoi prelevare questa cifra!! Hai il saldo disponibile minore dell'importo richiesto!!!-------") { };
                 
                }
                contoScelto.Saldo = contoScelto.Saldo - importo; 
            }
            else
                contoScelto.Saldo = contoScelto.Saldo + importo;



        }

        public static Tipo TipoCarta()
        {
            Console.WriteLine($"Premi {(int)Tipo.AMEX} per usare una carta {Tipo.AMEX}");
            Console.WriteLine($"Premi {(int)Tipo.VISA} per usare una carta {Tipo.VISA}");
            Console.WriteLine($"Premi {(int)Tipo.MASTERCARD} per usare una carta {Tipo.MASTERCARD}");
            Console.WriteLine($"Premi {(int)Tipo.OTHER} per usare una carta {Tipo.OTHER}");
            int tipo = CheckCarta();
            return (Tipo)tipo;

        }
        public static int CheckCarta()
        {
            int num = 0;
            while (!int.TryParse(Console.ReadLine(), out num) || num < 0 || num > 3)
            {
                Console.Write("Puoi inserire solo 0, 1, 2 e 3! Riprova: ");
            }

            return num;

        }

        public static bool PrelievoVersamento()
        {
            bool isPre = false;
            Console.WriteLine("Vuoi effettuare un Prelievo o un Versamento?" +
                "Premi \n\n[1] Prelievo\n[2] Versamento");
            int scelta = CheckChoice();
            if (scelta == 1)
                isPre = true;

            return isPre;

        }

        public static int CheckChoice()
        {
            int num = 0;
            while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 2)
            {
                Console.Write("Puoi inserire solo 1 o 2! Riprova: ");
            }

            return num;

        }

        public static void Stampa()
        {
            foreach(ContoCorrente conto in conti)
            {
                Console.WriteLine($"Numero Conto : {conto.NumeroConto}");
                Console.WriteLine($"Nome Banca: {conto.NomeBanca}");
                Console.WriteLine($"Saldo: {conto.Saldo}");
                Console.WriteLine($"Data Ultima Operazione: {conto.DataUltimaOperazione}");
                Console.WriteLine("Movimenti effettuati:");
                foreach(Movimento movimento in conto.Movimenti)
                {
                    Console.WriteLine(movimento);
                }
            }
        }
    }
}