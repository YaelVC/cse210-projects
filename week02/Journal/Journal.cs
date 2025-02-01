using ClosedXML.Excel;
using System.Diagnostics;

public class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void NewEntry()
    {
        List<string> prompts = new List<string>();

        prompts = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something I learned today?",
            "Describe a moment that made me smile today.",
            "What challenge did I overcome today?",
            "What am I grateful for today?",
            "How did I take care of myself today?"
        ];

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

        JournalEntry entry = new JournalEntry();
        entry.prompt = prompt;
        entry.response = response;
        entry.date = date;
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (JournalEntry entry in entries)
        {
            Console.WriteLine($"Date: {entry.date}");
            Console.WriteLine($"Prompt: {entry.prompt}");
            Console.WriteLine($"Response: {entry.response}");
            Console.WriteLine("");
        }
    }

    public void SaveJournalFile()
    {
        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in entries)
            {
                writer.WriteLine($"{entry.date}|{entry.prompt}|{entry.response}");
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadJournalFile()
    {
        Console.Write("Enter a filename to load the journal: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    JournalEntry entry = new JournalEntry { date = parts[0], prompt = parts[1], response = parts[2] };
                    entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded from file.");

            foreach (JournalEntry entry in entries)
            {
                Console.WriteLine($"Date: {entry.date}");
                Console.WriteLine($"Prompt: {entry.prompt}");
                Console.WriteLine($"Response: {entry.response}");
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }


    public void SaveJournalToExcel()
    {
        try
        {
            Console.Write("Enter a filename to save the journal (e.g., journal.xlsx): ");
            string filename = Console.ReadLine();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Journal");
                worksheet.Cell(1, 1).Value = "Date";
                worksheet.Cell(1, 2).Value = "Prompt";
                worksheet.Cell(1, 3).Value = "Response";

                for (int i = 0; i < entries.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = entries[i].date;
                    worksheet.Cell(i + 2, 2).Value = entries[i].prompt;
                    worksheet.Cell(i + 2, 3).Value = entries[i].response;
                }

                workbook.SaveAs(filename);
            }
            Console.WriteLine("Journal saved to Excel file.");
            Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the journal: {ex.Message}");
        }
    }

    public void LoadJournalFromExcel()
    {
        try
        {
            Console.Write("Enter a filename to load the journal (e.g., journal.xlsx): ");
            string filename = Console.ReadLine();
            if (File.Exists(filename))
            {
                entries.Clear();
                using (var workbook = new XLWorkbook(filename))
                {
                    var worksheet = workbook.Worksheet("Journal");
                    var rows = worksheet.RowsUsed();
                    foreach (var row in rows)
                    {
                        if (row.RowNumber() == 1) continue; // Skip header row

                        var dateCell = row.Cell(1);
                        var promptCell = row.Cell(2);
                        var responseCell = row.Cell(3);

                        // Ensure all values exist and are of the correct type
                        if (dateCell.IsEmpty() || promptCell.IsEmpty() || responseCell.IsEmpty())
                        {
                            Console.WriteLine($"Skipping row {row.RowNumber()} due to missing values.");
                            continue;
                        }

                        if (!DateTime.TryParse(dateCell.GetString(), out DateTime date))
                        {
                            Console.WriteLine($"Invalid date format in row {row.RowNumber()}");
                            continue;
                        }


                        string dateRow = row.Cell(1).GetString();
                        string promptRow = row.Cell(2).GetString();
                        string responseRow = row.Cell(3).GetString();

                        JournalEntry entry = new JournalEntry()
                        {
                            date = dateRow,
                            prompt = promptRow,
                            response = responseRow,
                        };

                        entries.Add(entry);
                    }
                }
                Console.WriteLine("Journal loaded from Excel file.");

                foreach (JournalEntry entry in entries)
                {
                    Console.WriteLine($"Date: {entry.date}");
                    Console.WriteLine($"Prompt: {entry.prompt}");
                    Console.WriteLine($"Response: {entry.response}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}");
        }
    }
}