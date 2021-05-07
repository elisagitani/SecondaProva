using System;
using System.Collections.Generic;
using System.Text;

namespace SecondaProva
{
    class Agenda
    {
        private Dictionary<int, Task> _tasks = new Dictionary<int, Task>();
        private static int _num;    // per attribuire il numero alla nuova task

        public Task CreaTask(string descrizione, DateTime dataDiscadenza, Priorita importanza)
        {
            Task task = new Task(descrizione, dataDiscadenza, importanza, ++_num);
            _tasks.Add(task.Numero, task);

            return task;
        }

        internal string OttieniTask(Formato formato)
        {

            string s = "";

            foreach (Task t in _tasks.Values)
                s += t.OttieniDati(formato) + '\n';


            return s;

        }

        public bool Esiste(int numero)
        {
            return _tasks.ContainsKey(numero);
        }

        internal bool EliminaTask(int numero)
        {
            return _tasks.Remove(numero);
        }

        public string FiltraDati(Priorita importanza, Formato formato)
        {
            string s = "";
            foreach (Task t in _tasks.Values)
            {
                if (t.Importanza == importanza)
                    s += t.OttieniDati(formato) + '\n';
                
            }
            return s;
        
        }


    }
}
