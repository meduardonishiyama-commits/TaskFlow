using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Ondoro
{
    public static class TaskRepository
    {
        // Função de Carregar
        public static List<TaskItem> LoadTasks()
        {
            if (!File.Exists("tasks.json")) //Verifica se o arquivo existe. Se não existir, retorna uma lista vazia.
            {
                return new List<TaskItem>();
            }

            string json = File.ReadAllText("tasks.json"); //Cria uma variável 'json' e lê o conteúdo do arquivo 'tasks.json' para ela. O conteúdo é uma string JSON.
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>(); //Deserializa a string JSON para uma lista de objetos TaskItem. Se a deserialização falhar (retornar null), retorna uma lista vazia.
        }

        // Função de Salvar
        public static void SaveTasks(List<TaskItem> tasks)
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("tasks.json", json);
        }
    }
}