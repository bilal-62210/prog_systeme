﻿using System;
using System.Collections.Generic;
using System.Text;

namespace appli_console
{
    class view
    {
        public void debut()
        {
            // Ask the user to choose an option.
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\tm - Modify");
            Console.WriteLine("\td - Delete");
            Console.WriteLine("\tr - Read");
            Console.WriteLine("\tq - Quit");
            Console.Write("Your option : ");
        }
       public void fin()
        {
            Console.Write("\n Press any key to close the Calculator console app...");
            Console.ReadKey();
        }

    }
}
