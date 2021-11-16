using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

        /*public void List()
        {
            for (int i = 0; i < ListSave.Count; i++)
            {
                Console.WriteLine(ListSave[i]);
            }
        }*/

        public void read()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\prog_systeme\\test.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("reading finally succeed.");
            }
        }

        public void Create(string NameSave, string SourceSave, string TargetSave, string TypeSave)
        {
            string path = @"C:\\prog_systeme\\test.txt";
            string[] lines = { NameSave, SourceSave, TargetSave, TypeSave };

            foreach (string line in lines)
            {
                File.AppendAllText(path, "\n");
                File.AppendAllText(path, line);
            }
            File.AppendAllText(path, "\n");
            /*Nb += 1;
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
            }*/
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
