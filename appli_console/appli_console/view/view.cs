using System;
using System.Collections.Generic;
using System.Text;

namespace appli_console
{
    class view
    {
        public void debut()
        {
            Console.WriteLine("Choose an option from the following list:/Choisissez une option dans la liste suivante :");
            Console.WriteLine("\ta - Add/ajouter");
            Console.WriteLine("\tm - Modify/modifier");
            Console.WriteLine("\td - Delete/supprimer");
            Console.WriteLine("\tr - Read/lire");
            Console.WriteLine("\ts - Execute save/executer sauvegarde");
            Console.WriteLine("\tp - Sequential save/ sauvegarde sequentielle");
            Console.WriteLine("\tq - Quit/quitter");
            Console.Write("Your option : /votre option:");
        }
        public void fin()
        {
            Console.Write("\n Press any key to close the Calculator console app.../appuyer sur une touche pour fermer la console");
            Console.ReadKey();
        }

    }
}
