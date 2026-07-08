using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Ondoro
{
    class Program
    {
        // 'args' são os argumentos/comandos passados na inicialização via terminal (ex: dotnet run arg1 arg2).
        // Entram sempre como um array de textos (string[]) porque texto é o dado mais genérico.
        static void Main(string[] args)
        {
            // Lista elástica na memória RAM. O 'new();' é o atalho moderno para não repetir o nome da classe.
            // Poderíamos apenas declarar a variável antes e dar o 'new()' só quando o usuário fosse usar.
            List<TaskItem> myTasks = TaskRepository.LoadTasks();
            int nextId = myTasks.Any() ? myTasks.Max(t => t.Id) + 1 : 1;

            Console.WriteLine("===================================");
            Console.WriteLine("     Welcome to ONDORO CLI!      ");
            Console.WriteLine("===================================\n");

            // Aqui vai morar o loop do menu (while + switch)
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Add a new task");
                Console.WriteLine("2. List all tasks");
                Console.WriteLine("3. Mark a task as complete");
                Console.WriteLine("4. Delete a task");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                // Se o ReadLine devolver null, a variável 'choice' recebe um texto vazio "" automaticamente
                // Captura com segurança: se vier nulo ou com espaços extras, ele limpa e protege
                string choice = (Console.ReadLine() ?? "").Trim();

                switch (choice)
                {
                    case "1":
                        Functions.AddTask(myTasks, ref nextId);
                        break;
                    case "2":
                        Functions.ListTasks(myTasks);
                        break;
                    case "3":
                        Functions.MarkTaskComplete(myTasks);
                        break;
                    case "4":
                        Functions.DeleteTask(myTasks);
                        break;
                    case "5":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}