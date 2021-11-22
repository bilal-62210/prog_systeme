using System;
using System.Collections.Generic;
using System.Text;

namespace appli_console
{
    class viewmodel:model
    {
        public void demarrage()
        {
            view view = new view();
            var etat = true;

            while (etat == true)
            {
                view.debut();
                // Use a switch statement to do the math.
                switch (Console.ReadLine())
                {
                    case "a":
                        Console.Write("Name of the save : ");
                        var NameSave = Console.ReadLine();
                        Console.Write("Source of the save : ");
                        var SourceSave = Console.ReadLine();
                        Console.Write("Cible of the save : ");
                        var TargetSave = Console.ReadLine();
                        Console.Write("Type of the save : ");
                        var TypeSave = Console.ReadLine();

                        Console.Write(NameSave + ' ' + SourceSave + ' ' + TargetSave + ' ' + TypeSave);
                        Create(NameSave, SourceSave, TargetSave, TypeSave);

                        break;
                    case "m":
                        Modify();
                        break;
                    case "d":
                        Delete();
                        break;
                    case "r":
                        read();
                        break;
                    case "s":
                        Console.Write("Name of the save : ");
                        var ChoixNom = Console.ReadLine();
                        Save(ChoixNom);
                        break;
                    case "q":
                        etat = false;
                        break;
                    case "p":
                        SequentialSave();
                        break;
                }
            }
            view.fin();
        }
    }
}

