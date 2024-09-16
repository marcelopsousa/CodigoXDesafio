using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskRotina
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            int quantidadeDeTarefas = 10;
            List<Task> tarefas = new List<Task>();

            for (int i = 1; i <= quantidadeDeTarefas; i++)
            {
                tarefas.Add(ProcessarTarefaAsync(i));
            }
            await Task.WhenAll(tarefas);

            Console.WriteLine("Todas as tarefas foram processadas.");
        }

        static async Task ProcessarTarefaAsync(int idTarefa)
        {
            Random random = new Random();
            int tempoEspera = random.Next(1000, 5000);

            await Task.Delay(tempoEspera);

            Console.WriteLine($"Tarefa {idTarefa} processada em {tempoEspera / 1000.0} segundos.");
        }
    }

}
