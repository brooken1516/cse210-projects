// For the creativity/exceeding requirements I added to the HideRandomWords() 
//code that would not let it select words that were already hidden. 

using System;

class Program
{
    static void Main(string[] args)
    {
        Reference ref1 = new Reference("2 Timothy", 1, 7, 9 );

        Scripture myScripture = new Scripture(ref1, "For God hath not given us the spirit of fear; " 
        + "but of power, and of love, and of a sound mind. Be not thou therefore ashamed of the testimony "
        + "of our Lord, nor of me his prisoner; but be thou partaker of the afflictions of the gospel "
        + "according to the power of God; Who hath saved us, and called us with a holy calling, not "
        + "according to our works, but according to his own purpose and grace, which was given us in Christ "
        + "Jesus before the world began,");

        while (!myScripture.IsCompletelyHidden())
        {
            Console.Clear();
            
            Console.WriteLine(myScripture.GetDisplayText());

            Console.WriteLine("Press enter to hide words, or type 'quit'. ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                break;
            }
            else
            {
                myScripture.HideRandomWords();
            }
        }
        if (myScripture.IsCompletelyHidden())
        {
            Console.WriteLine("Congrats! All the words are hidden! ");
        }
        else
        {
            Console.WriteLine("You entered 'quit.' Please, visit again soon. ");
        }
    }
}

