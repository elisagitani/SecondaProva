using System;
using System.Collections.Generic;
using System.IO;


namespace SecondaProva
{
    enum Priorita
    {
        Bassa,
        Media,
        Alta
    }
    enum Formato
    {
        Normal,
        TSV
    }
    class Program

    {
        private static string fileName = @"agenda.txt";
        private static Agenda agenda = new Agenda();
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nella tua agenda personale");
            Console.WriteLine();

            bool finito = false;

            //Creazione menù
            do
            {
                Console.WriteLine("1. Aggiungere un nuovo Task");
                Console.WriteLine("2. Vedere i Task inseriti");
                Console.WriteLine("3. Eliminare un Task");
                Console.WriteLine("4. Filtrare i Task per importanza");
                Console.WriteLine("5. Salva");
                Console.WriteLine("0. Esci");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        AggiungiTask();
                        break;
                    case '2':
                        VisualizzaTask();
                        break;
                    case '3':
                        EliminaTask();
                        break;
                    case '4':
                        FiltraTask();
                        break;
                    case '5':
                        Salva();
                        break;
                    case '0':
                        finito = true;
                        break;
                    default:
                        Console.WriteLine("\nScelta errata");
                        break;
                }

            } while (!finito);
        }

        private static void Salva()
        {
            
                using (StreamWriter sw = new StreamWriter(fileName))
                    sw.Write(agenda.OttieniTask(Formato.TSV));
            
        }

        private static void FiltraTask()
        {
            Priorita scelta;
           
                Console.WriteLine("\nScegli l'importanza delle task che vuoi vedere (Alta, Media o Bassa):");
                scelta = (Priorita)Enum.Parse(typeof(Priorita), Console.ReadLine());  
                Console.WriteLine(agenda.FiltraDati(scelta,Formato.Normal));

        }

        private static void EliminaTask()
        {
            
                int numero;
                do
                    Console.Write("\nTask da eliminare: ");
                while (!int.TryParse(Console.ReadLine(), out numero));


                if (agenda.EliminaTask(numero))
                    Console.WriteLine($"La task {numero} è stata eliminata");
                else
                    Console.WriteLine($"Task {numero} non esistente");
           
        }

        private static void VisualizzaTask()
        {
            Console.WriteLine();
            Console.WriteLine(agenda.OttieniTask(Formato.Normal));

        }

        private static void AggiungiTask()
        {
            Console.WriteLine();
            //crea una task 
            string descrizione;
            do
            {
                Console.Write("Descrizione: ");
                descrizione = Console.ReadLine();
            }
            while (descrizione.Length == 0);

            DateTime dataScadenza;
            do
            {
                Console.Write("Inserisci una data di scadenza: ");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out dataScadenza)|| dataScadenza<DateTime.Today);

            Priorita importanza;

                Console.Write("Inserisci importanza Alta, Media o Bassa: ");
                importanza = (Priorita)Enum.Parse(typeof(Priorita), Console.ReadLine());
           

            Task task = agenda.CreaTask(descrizione, dataScadenza, importanza);

            Console.WriteLine($"Task numero {task.Numero} descrizione: {task.Descrizione} data di scadenza: {task.DataDiScadenza.ToShortDateString()} importanza:{task.Importanza}");

        }
    }
}
