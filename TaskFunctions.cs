using System;
using System.Collections.Generic;

namespace Ondoro
{
    static class Functions
    {
        public static void AddTask(List<TaskItem> tasks, ref int nextId)
        {
            string title = "";

            while (string.IsNullOrWhiteSpace(title))
            {
                Console.Write("Enter task title: ");
                title = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Title cannot be empty. Please try again.");
                }
            }

            Console.Write("Enter task category: ");
            string category = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrWhiteSpace(category))
            {
                category = "General";
            }

            TaskItem newTask = new()
            {
                Id = nextId++,
                Title = title,
                Category = category,
                IsCompleted = false
            };

            tasks.Add(newTask);
            TaskRepository.SaveTasks(tasks);

            Console.WriteLine($"\nTask '{newTask.Title}' added successfully! (ID: {newTask.Id})");
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }

        public static void ListTasks(List<TaskItem> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("\nNo tasks found. Add one first!");
            }
            else
            {
                Console.WriteLine("\n--- Your Tasks ---");
                foreach (TaskItem task in tasks)
                {
                    string status = task.IsCompleted ? "[X]" : "[ ]";
                    Console.WriteLine($"{task.Id}. {status} {task.Title} (Category: {task.Category})");
                }
            }
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }

        public static void MarkTaskComplete(List<TaskItem> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("\nNo tasks to update. Add one first!");
                return;
            }

            Console.Write("Enter the ID of the task to mark as complete: ");
            string idInput = (Console.ReadLine() ?? "").Trim();

            if (int.TryParse(idInput, out int idToComplete))
            {
                TaskItem? taskToUpdate = tasks.Find(t => t.Id == idToComplete);

                if (taskToUpdate != null)
                {
                    taskToUpdate.IsCompleted = true;
                    TaskRepository.SaveTasks(tasks);
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

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void DeleteTask(List<TaskItem> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("\nNo tasks found.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter the ID of the task to delete: ");
            string deleteIdInput = (Console.ReadLine() ?? "").Trim();

            if (int.TryParse(deleteIdInput, out int idToDelete))
            {
                TaskItem? taskToRemove = tasks.Find(t => t.Id == idToDelete);

                if (taskToRemove != null)
                {
                    tasks.Remove(taskToRemove);
                    TaskRepository.SaveTasks(tasks);
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

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}