using System;
using System.IO

namespace appli_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var etat = true;

            while (etat == true)
            {
                // Ask the user to choose an option.
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\tm - Modify");
                Console.WriteLine("\td - Delete");
                Console.WriteLine("\tr - Read");
                Console.WriteLine("\tq - Quit");
                Console.Write("Your option : ");

                // Use a switch statement to do the math.
                switch (Console.ReadLine())
                {
                    case "a":
                        var result = new sauvegarde();

                        Console.Write("Name of the save : ");
                        var NameSave = Console.ReadLine();
                        Console.Write("Source of the save : ");
                        var SourceSave = Console.ReadLine();
                        Console.Write("Cible of the save : ");
                        var TargetSave = Console.ReadLine();
                        Console.Write("Type of the save : ");
                        var TypeSave = Console.ReadLine();

                        Console.Write(NameSave + ' ' + SourceSave + ' ' + TargetSave + ' ' + TypeSave);
                        //Pass the filepath and filename to the StreamWriter Constructor
                        StreamWriter sw = new StreamWriter("");
                        //Write a line of text
                        sw.WriteLine("Hello World!!");
                        //Write a second line of text
                        sw.WriteLine("From the StreamWriter class");
                        //Close the file
                        sw.Close();
                        // result.Create(NameSave, SourceSave, TargetSave, TypeSave);

                        break;
                    case "m":

                        break;
                    case "d":

                        break;
                    case "r":
                        var liste = new sauvegarde();
                        liste.List();
                        break;
                    case "q":
                        etat = false;
                        break;
                }
            }
            // Wait for the user to respond before closing.
            Console.Write("\n Press any key to close the Calculator console app...");
            Console.ReadKey();
        }
    }
}
