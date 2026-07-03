using System;
using System.Collections.Generic;

namespace TaskFlow
{
    // Representation of a Task
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public bool IsCompleted { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // In-memory list to store tasks
            List<TaskItem> myTasks = new List<TaskItem>();

            Console.WriteLine("===================================");
            Console.WriteLine("     Welcome to TaskFlow CLI!      ");
            Console.WriteLine("===================================\n");
            
            // This is where your logic loop will live
            Console.WriteLine("System initialized successfully. Ready to build!");
        }
    }
}