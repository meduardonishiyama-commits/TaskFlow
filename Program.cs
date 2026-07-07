using System;
using System.Collections.Generic;

namespace TaskFlow
{
    // Representação de uma Tarefa
    // Boa prática criar no início para leitura humana. Define o que é uma tarefa e suas propriedades.
    // Se for 'public', qualquer parte do sistema vê. Se omitido, vira 'internal' (visível na mesma pasta/projeto).
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public bool IsCompleted { get; set; }
    }

    class Program
    {
        // 'args' são os argumentos/comandos passados na inicialização via terminal (ex: dotnet run arg1 arg2).
        // Entram sempre como um array de textos (string[]) porque texto é o dado mais genérico.
        static void Main(string[] args)
        {
            // Lista elástica na memória RAM. O 'new();' é o atalho moderno para não repetir o nome da classe.
            // Poderíamos apenas declarar a variável antes e dar o 'new()' só quando o usuário fosse usar.
            List<TaskItem> myTasks = new();

            Console.WriteLine("===================================");
            Console.WriteLine("     Welcome to TaskFlow CLI!      ");
            Console.WriteLine("===================================\n");

            int nextId = 1;
            
            // Aqui vai morar o loop do menu (while + switch)
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Add a new task");
                Console.WriteLine("2. List all tasks");
                Console.WriteLine("3. Exit");
                Console.WriteLine("4. Mark a task as complete");
                Console.WriteLine("5. Delete a task");
                Console.Write("Enter your choice: ");

                // Se o ReadLine devolver null, a variável 'choice' recebe um texto vazio "" automaticamente
                // Captura com segurança: se vier nulo ou com espaços extras, ele limpa e protege
                string choice = (Console.ReadLine() ?? "").Trim();

                switch (choice)
                {
                    case "1":
                    {
                        // 1. Inicializamos com um texto vazio, garantindo que NUNCA será null
                        string title = "";

                        while (string.IsNullOrWhiteSpace(title))
                        {
                            Console.Write("Enter task title: ");
                            // Protegemos com ?? "" e já limpamos os espaços com o Trim()
                            title = (Console.ReadLine() ?? "").Trim();

                            if (string.IsNullOrWhiteSpace(title))
                            {
                                Console.WriteLine("Title cannot be empty. Please try again.");
                            }
                        }

                        Console.Write("Enter task category: ");
                        // Se o usuário não digitar nada na categoria, ela vira "General" automaticamente
                        string category = (Console.ReadLine() ?? "").Trim();
                        if (string.IsNullOrWhiteSpace(category))
                        {
                            category = "General";
                        }

                        // 2. O C# agora tem 100% de certeza que title e category são textos válidos
                        TaskItem newTask = new TaskItem
                        {
                            Id = nextId++,
                            Title = title,
                            Category = category,
                            IsCompleted = false
                        };

                        myTasks.Add(newTask);

                        Console.WriteLine($"\nTask '{newTask.Title}' added successfully! (ID: {newTask.Id})");
                        break;
                    }    
                    case "2":
                    { 
                        if (myTasks.Count == 0)
                        {
                            Console.WriteLine("\nNo tasks found. Add one first!");
                        }
                        else
                        {
                            Console.WriteLine("\n--- Your Tasks ---");
                            foreach (TaskItem task in myTasks)
                            {
                                string status = task.IsCompleted ? "[X]" : "[ ]";
                                Console.WriteLine($"{task.Id}. {status} {task.Title} (Category: {task.Category})");
                            }
                        }
                        break;
                    }    
                    case "3":
                    {
                        Console.WriteLine("Exiting the application. Goodbye!");
                        keepRunning = false;
                        break;
                    }
                    case "4":
                    {
                        if (myTasks.Count == 0)
                        {
                            Console.WriteLine("\nNo tasks to update. Add one first!");
                            break;
                        }
                        Console.Write("Enter the ID of the task to mark as complete: ");
                        string idInput = (Console.ReadLine() ?? "").Trim();

                        if (int.TryParse(idInput, out int idToComplete))
                        {
                            TaskItem taskToUpdate = myTasks.Find(t => t.Id == idToComplete); //LAMBDA

                            if (taskToUpdate != null)
                            {
                                taskToUpdate.IsCompleted = true;
                                Console.WriteLine($"\nTask '{taskToUpdate.Title}' marked as complete!");
                            }
                            else
                            {
                                Console.WriteLine("\nNo task found with that ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. Please enter a numeric ID.");
                        }
                        break;
                    }
                    case "5":
                    {
                        if (myTasks.Count == 0)
                        {
                            Console.WriteLine("\nNo tasks to delete. Add one first!");
                            break;
                        }

                        Console.Write("Enter the ID of the task to delete: ");
                        string deleteIdInput = (Console.ReadLine() ?? "").Trim();

                        if (int.TryParse(deleteIdInput, out int idToDelete))
                        {
                            TaskItem taskToRemove = myTasks.Find(t => t.Id == idToDelete);

                            if (taskToRemove != null)
                            {
                                myTasks.Remove(taskToRemove);
                                Console.WriteLine($"\nTask '{taskToRemove.Title}' deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("\nNo task found with that ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input. Please enter a numeric ID.");
                        }
                        break;
                    }
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}