using System;
using System.Collections.Generic;
namespace Capstone2
{
    class Program
    {
        public static List<Task> tasks = new List<Task>()
        {
            new Task("Steve", "Grade stuff.", "04/20/2020"),
            new Task("Joey Wheeler", "Find yugi.", "06/8/2002"),
            new Task("Iron Man", "Save the world.", DateTime.Now.ToShortDateString()),
            new Task("Aaron", "Complete lab 10", "10/25/2019")
        };
        static string exiting = "n";
        static void Main(string[] args)
        {
            while (exiting != "y")
            {
                PromptUser();
                if (exiting != "y")
                {
                    Rerun();
                }

            }

        }
        static void PromptUser()
        {
            int selection = ParseIntFromString($"Select an option\n1) List Tasks\n2) Add Task\n3) Remove Task\n4) Mark Task Comeplete\n5) Exit");
            switch (selection + 1)
            {
                case 1:
                    ListTasks();
                    break;
                case 2:
                    AddTask();
                    break;
                case 3:
                    RemoveTask();
                    break;
                case 4:
                    MarkTaskComplete();
                    break;
                case 5:
                    Rerun();
                    break;
                case 6:
                    Console.WriteLine($"SUUUWOOOOOOOOOOOOOOOOOOOOOOOOOOOOOP");
                    break;
                default:
                    Console.WriteLine("not a valid selection, try again");
                    PromptUser();
                    break;
            }
        }
        static void MarkTaskComplete()
        {
            ListTasks();
            int selection = (ParseIntFromString("What Task would you like to mark complete?", 1, tasks.Count));
            switch (ParseIntFromString($"Are you sure you want to mark task complete?\n1) Yes\n2) No", 1, 2) + 1)
            {
                case 1:
                    tasks[selection].SetComplete();
                    Console.WriteLine("Check!");
                    break;
                case 2:

                    break;
                default:
                    break;
            }

        }
        static void RemoveTask() 
        {
            ListTasks();
            int selection = ParseIntFromString("What Task would you like to remove?", 1, tasks.Count);
            switch (ParseIntFromString($"Are you sure you want to delete task {selection+1}?\n1) Yes\n2) No", 1, 2)+1)
            {
                case 1:
                    tasks.RemoveAt(selection);
                    Console.WriteLine("Task removed!");
                    break;
                case 2:

                    break;
                default:
                    break;
            }
        }
        static void AddTask()
        {
            tasks.Add(new Task(GetInput("Assigned Member: "), GetInput("Task Description: "), GetInput("Due date(mm/dd/yyyy): ", true)));
            Console.WriteLine("Task has been added! ");
        }
        static void ListTasks()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {tasks[i].ToString()}");
                Console.WriteLine();
            }
        }
        static string GetInput(string message, bool isDate = false)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("Input cannot be blank");
                return GetInput(message);
            }
            else
            {
                DateTime date;
                if (isDate && DateTime.TryParse(input, out date))
                {
                    input = date.ToShortDateString();
                }
                else if (isDate)
                {
                    Console.WriteLine("Not a valid date, try again");
                    return GetInput(message, isDate);
                }
                return input;
            }
        }
        static int ParseIntFromString(string message)
        {
            try
            {
                return int.Parse(GetInput(message)) - 1;
            }
            catch
            {
                Console.WriteLine("Something went wrong, please try again(Looking for a number): ");
                return ParseIntFromString(message);
            }
        }
        static int ParseIntFromString(string message, int inclusiveMin, int inclusiveMax)
        {
            try
            {
                int input = int.Parse(GetInput(message));
                if (input <= inclusiveMax && input >= inclusiveMin)
                {
                    return input-1;
                }
                else
                {
                    Console.WriteLine("Out of Range, try again");
                    return ParseIntFromString(message, inclusiveMin, inclusiveMax);
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong, please try again(Looking for a number): ");
                return ParseIntFromString(message);
            }
        }
        static void Rerun()
        {
            exiting = GetInput("Would you like to exit?(y/n): ");
        }
    }
}
