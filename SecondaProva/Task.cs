using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SecondaProva
{
    class Task
    {
        public string Descrizione { get; }
        public DateTime DataDiScadenza { get; }
        public Priorita Importanza { get; }
        public int Numero { get; }


        public Task(string descrizione, DateTime dataDiscadenza, Priorita importanza, int numero)
        {
            Descrizione = descrizione;
            Importanza = importanza;
            Numero = numero;

            if (dataDiscadenza < DateTime.Today)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
                DataDiScadenza = dataDiscadenza;

        }

        public string OttieniDati(Formato formato)
        {
            switch (formato)
            {
                case Formato.Normal:
                    return $"Task {Numero} Descrizione: {Descrizione}, data di scadenza: {DataDiScadenza.ToShortDateString()} importanza:{Importanza}";
                case Formato.TSV:
                    return $"{Numero}\t{Descrizione}\t{DataDiScadenza.ToShortDateString()}\t{Importanza}";
                default:
                    throw new ArgumentOutOfRangeException();


            }
        }



    }
}