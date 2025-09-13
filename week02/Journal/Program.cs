// To show creativity in option #2 by adding the option to show the journal entries by specific 
// date instead of just being displayed. 
// And then added a new step #3 to display the entries in chronological order (sorted by date).

using System;
using System.IO;
using System.Reflection.Emit;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator thePromptGenerator = new PromptGenerator();

        int choice = 0;

        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Add entry");
            Console.WriteLine("2. Display by date");
            Console.WriteLine("3. Display All (chronological order)");
            Console.WriteLine("4. View all (unsorted/original order)");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Quit");

            bool validInput = false;

            while (!validInput)
            {
                Console.Write("What would you like to do? (Please enter number for the option.) ");
                string userInput = Console.ReadLine();
                validInput = int.TryParse(userInput, out choice);

                if (!validInput || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6. ");
                    validInput = false;
                }
            }

            if (choice == 1)
            {
                string prompt = thePromptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                Entry anEntry = new Entry(prompt, response);
                theJournal.AddEntry(anEntry);
                anEntry.Display();
            }
            else if (choice == 2)
            {
                Console.Write("Which date would you like to view your journal entries? (MM/DD/YYYY) ");
                string inputTwo = Console.ReadLine();
                DateTime dateToFind;
                bool validDate = DateTime.TryParse(inputTwo, out dateToFind);
                if (validDate)
                {
                    bool found = false;
                    foreach (Entry anEntry in theJournal._entries)
                    {
                        if (anEntry._date == dateToFind.ToShortDateString())
                        {
                            anEntry.Display();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("No entries found for that date. ");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect date format. Please enter as MM/DD/YYYY. ");
                }
            }
            else if (choice == 3)
            {
                theJournal.DisplayChronological();
            }
            else if (choice == 4)
            {
                theJournal.DisplayAll();
            }
            else if (choice == 5)
            {
                Console.WriteLine("Enter a filename to save your journal entries ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }

            else if (choice == 6)
            {
                Console.WriteLine("See you next time! ");
            }
        } while (choice != 6);     
    }
}