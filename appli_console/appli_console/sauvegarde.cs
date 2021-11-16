using System;
using System.Collections.Generic;
using System.Text;

namespace appli_console
{
    class sauvegarde
    {
        protected string Name;
        protected string Source;
        protected string Target;
        protected string Type;
        protected Boolean Choix;
        protected int Temps;
        protected int Nb = 0;
        protected List<string> ListSave = new List<string>();

        public void List()
        {
            for (int i = 0; i < ListSave.Count; i++)
            {
                Console.WriteLine(ListSave[i]);
            }
        }

        public void Create(string NameSave, string SourceSave, string TargetSave, string TypeSave)
        {
            Nb += 1;
            if (Nb < 5)
            {
                ListSave.Add(NameSave);
                ListSave.Add(SourceSave);
                ListSave.Add(TargetSave);
                ListSave.Add(TypeSave);
                ListSave.Add("n");
            }
            else
            {
                Environment.Exit(0);
            }
        }
        private void Modify(string NameSave, string SourceSave, string TargetSave, string TypeSave)
        {

        }
        private void Delete(string NameSave)
        {

        }
        private void Save(string NameSave)
        {

        }
        private void SequentialSave(string NameSave, Boolean ChoixSequentail, int TempsSequential)
        {

        }
    }
}
