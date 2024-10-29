using System.Diagnostics;

Console.WriteLine("Iniciando o processamento das tarefas...");

// Número de tarefas a serem processadas
int numberOfTasks = 10;
var tasks = new List<Task>();

// Criar e iniciar as tarefas
for (int i = 1; i <= numberOfTasks; i++)
{
    int taskId = i; // Captura o ID da tarefa
    tasks.Add(ProcessTaskAsync(taskId));
}

// Aguardar todas as tarefas serem concluídas
await Task.WhenAll(tasks);

Console.WriteLine("Todas as tarefas foram processadas.");

// Método que simula o processamento de uma tarefa
static async Task ProcessTaskAsync(int taskId)
{
    // Gerar um tempo de espera aleatório entre 1 e 5 segundos
    Random random = new Random();
    int delay = random.Next(1000, 5001); // Em milissegundos
    Stopwatch stopwatch = Stopwatch.StartNew();

    await Task.Delay(delay); // Espera de forma assíncrona

    stopwatch.Stop();
    Console.WriteLine($"Tarefa ID: {taskId}, Tempo de execução: {stopwatch.ElapsedMilliseconds} ms");
}
