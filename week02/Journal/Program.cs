using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> menu = [
             "Write a new entry",
              "Display the journal",
              "Save the journal to a file",
              "Load the journal from a file",
              "Save the journal to a Excel file",
              "Load the journal from a Excel file",
              "Exit",
        ];

        while (true)
        {
            Console.WriteLine("\nMenu:");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }

            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.NewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournalFile();
                    break;
                case "4":
                    journal.LoadJournalFile();
                    break;
                case "5":
                    journal.SaveJournalToExcel();
                    break;
                case "6":
                    journal.LoadJournalFromExcel();
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}